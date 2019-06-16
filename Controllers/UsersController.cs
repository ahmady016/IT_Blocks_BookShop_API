using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Web_API.EntityModels;
using Web_API.ViewModels;

namespace Web_API
{
  // Inherit from BaseCOntroller to get all the actions inside it in the derived controller
  [Authorize]
  public class UsersController : BaseController<User, int, UserView>
  {
    // Store the BaseService object that comes from [DI] which injects it in the constructor
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private static string _tableName = "Users";
    private User user;
    private UserView vUser;

    // do Change the userPassword with the newPassword
    private IActionResult _DoChangePassword(User user, string newPassword)
    {
      // (3) hashing the new password and set the passwordSalt and passwordHash
      user.PasswordSalt = UserHelpers.GetSecuredRandStr();
      user.PasswordHash = UserHelpers.Hashing(newPassword, user.PasswordSalt);
      // (4) Saving the new passwordSalt and passwordHash
      _service.Save();
      // (5) Map the Entity User to View User [VUser]
      vUser = _mapper.Map<UserView>(user);
      // (6) if everything is ok, return the full vUser
      return Ok(vUser);
    }
    // Give the BaseConstructor the dependency it needs which is DB Service, AutoMapper, tableName, keyName
    public UsersController(BaseService service, IMapper mapper, IConfiguration config)
                        : base(service, mapper, _tableName, "userId")
    {
      // DI inject usersService object here from startup Class
      _service = service;
      _mapper = mapper;
      _config = config;
    }

    #region UserController Actions

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public IActionResult SignUp(SignUp signUp)
    {
      // (1) Generate password Hash and salt
      // (_) Mapping from SignUp [View Model] to User [Entity Model]
      user = UserHelpers.ToUser(signUp);
      // (2) insert the User
      _service.Add(user);
      // (3) Map the Entity User to View User [VUser]
      vUser = _mapper.Map<UserView>(user);
      // (4) if everything is ok, return the [vUser - accessToken - refreshToken]
      return Ok(new
      {
        User = vUser,
        AccessToken = UserHelpers.GetToken(vUser)
      }
      );
    }
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public IActionResult SignIn(SignIn signIn)
    {
      // (1) Get User by his Credentials [userId - userPassword]
      // and validate the userPassword against Passwordhash
      user = _service.GetOne<User>(u => u.Email == signIn.Email && UserHelpers.ValidateHash(signIn.Password, u.PasswordSalt, u.PasswordHash));
      // (2) if User doesn't exist return badRequest
      if (user == null)
        return BadRequest(new Error() { Message = "Invalid User." });
      // (3) if User is [isDeleted] return badRequest
      if (user.IsDeleted == true)
        return BadRequest(new Error() { Message = "Invalid User." });
      // (4) Map the Entity User to View User [VUser]
      vUser = _mapper.Map<UserView>(user);
      // (5) if everything is ok, return the [vUser - accessToken]
      return Ok(new
      {
        User = vUser,
        AccessToken = UserHelpers.GetToken(vUser)
      }
      );
    }
    [AllowAnonymous]
    [HttpPost("change-password")]
    public IActionResult ChangePassword([FromBody]ChangedPassword changedpassword)
    {
      // (1) Get User by his Credentials [UserId - OldPassword]
      var user = _service.GetOne<User>(u => u.Email == changedpassword.Email && UserHelpers.ValidateHash(changedpassword.OldPassword, u.PasswordSalt, u.PasswordHash));
      // (2) if user not found then return [BadRequest]
      if (user == null)
        return BadRequest(new Error() { Message = "Invalid User." });
      return _DoChangePassword(user, changedpassword.NewPassword);
    }
    [AllowAnonymous]
    [HttpPost("forget-password")]
    public IActionResult ForgetPassword(ForgottenPassword forgottenPassword)
    {
      // if the code doesn't match the Master Code return Exception [BadRequest]
      if (forgottenPassword.VerificationCode != _config.GetValue<string>("MasterVerificationCode"))
        throw new Exception("Invalid Verification Code!!!");
      // get the user by Email
      user = _service.Find<User, string>(forgottenPassword.Email);
      // (_) If user not found then return Exception [BadRequest]
      if (user == null)
        throw new Exception("Invalid User !!!");
      // (_) if user and code ok then Change Password with the new one
      return _DoChangePassword(user, forgottenPassword.NewPassword);
    }
    #endregion
  }
}
