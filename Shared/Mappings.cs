using AutoMapper;
using Web_API.EntityModels;
using Web_API.ViewModels;

namespace Web_API
{
  public class Mappings : Profile
  {
    public Mappings()
    {
      CreateMap<User, UserView>().ReverseMap();
    }
  }
}