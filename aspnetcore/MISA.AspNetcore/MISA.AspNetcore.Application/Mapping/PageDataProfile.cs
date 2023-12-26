using AutoMapper;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class PageDataProfile<TEntity, TEnityDto> : Profile
    {
        public PageDataProfile()
        {
            CreateMap<PageData<TEntity>, PageDataDto<TEnityDto>>();
        }
    }
}
