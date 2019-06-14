using AutoMapper;
using Web_API.EntityModels;

namespace Web_API
{
  public class BorrowingsController : BaseController<Borrowing, int, Borrowing>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    public BorrowingsController(BaseService service, IMapper mapper)
                                : base(service, mapper, "Borrowings", "borrowingId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
