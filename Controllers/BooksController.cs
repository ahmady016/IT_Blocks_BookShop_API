using AutoMapper;
using Web_API.EntityModels;

namespace Web_API
{
  public class BooksController : BaseController<Book, int, Book>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    public BooksController(BaseService service, IMapper mapper)
                                : base(service, mapper, "Books", "bookId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
