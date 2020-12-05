using AutoMapper;
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
            //CreateMap<BookingRecordViewModel, BookingRecord>();
            //CreateMap<BookingRecord, BookingRecordViewModel>();

            //CreateMap<RoomViewModel, Room>();
            //CreateMap<Room, RoomViewModel>();

            //CreateMap<SettingsRecord, SettingsRecordViewModel>();
            //CreateMap<SettingsRecord, SettingsRecordViewModel>();

            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();


        }
    }
}
