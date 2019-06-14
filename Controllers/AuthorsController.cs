using AutoMapper;
using Web_API.EntityModels;

namespace Web_API
{
  public class AuthorsController : BaseController<Author, int, Author>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    public AuthorsController(BaseService service, IMapper mapper)
                                : base(service, mapper, "Authors", "authorId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
