using MISA.AspNetcore.Application;

namespace MISA.AspNetcore.Controllers
{
    public class PositionsController : BaseReadOnlyController<Guid, PositionDto>
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService) : base(positionService)
        {
            _positionService = positionService;
        }
    }
}
