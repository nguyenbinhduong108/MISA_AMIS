using AutoMapper;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class PositionService : BaseReadOnlyService<Positions, Guid, PositionDto>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper) : base(positionRepository)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public override PositionDto MapTEntityToTEntityDto(Positions positions)
        {
            var positionDto = _mapper.Map<Positions, PositionDto>(positions);

            return positionDto;
        }
    }
}
