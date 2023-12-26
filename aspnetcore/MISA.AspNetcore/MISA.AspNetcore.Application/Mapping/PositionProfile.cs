using AutoMapper;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Positions, PositionDto>();    
        }
    }
}
