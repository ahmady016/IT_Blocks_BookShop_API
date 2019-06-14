using AutoMapper;
using Web_API.EntityModels;

namespace Web_API
{
  public class CustomersController : BaseController<Customer, int, Customer>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    public CustomersController(BaseService service, IMapper mapper)
                                : base(service, mapper, "Customers", "customerId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
