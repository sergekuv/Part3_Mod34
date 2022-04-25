using AutoMapper;
using Part3_Mod34.Configuration;
using Part3_Mod34.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part3_Mod34
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>().ForMember(m => m.AddressInfo,opt => opt.MapFrom(src => src.Address));
        }
    }
}
