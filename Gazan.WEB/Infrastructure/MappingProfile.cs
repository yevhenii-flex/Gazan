using AutoMapper;
using Gazan.Backend.Models;
using Gazan.WEB.Models;
using Gazan.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gazan.WEB.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();

            CreateMap<CriticalValue, CriticalValueViewModel>().ForMember(m => m.HarmfulSubstanceName, opt => opt.MapFrom(src => src.HarmfulSubstance.Name));
            CreateMap<CriticalValueViewModel, CriticalValue>();
        }
    }
}
