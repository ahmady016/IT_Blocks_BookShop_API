using AutoMapper;
using Web_API.EntityModels;

namespace Web_API
{
  public class PurchasesController : BaseController<Purchase, int, Purchase>
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    public PurchasesController(BaseService service, IMapper mapper)
                                : base(service, mapper, "Purchases", "purchaseId")
    {
      _service = service;
      _mapper = mapper;
    }
  }
}
