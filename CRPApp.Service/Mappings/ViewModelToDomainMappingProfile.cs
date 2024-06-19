using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRPApp.Data.DBModels;
using CRPApp.Data.ViewModels;

namespace CRPApp.Service.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //  Map ONLY those specific fields where it is not clear for Automapper to do the mapping
            CreateMap<OnsiteStatusViewModel, CRPOnsiteStatus>()

                .ForMember(dest => dest.LastCRPDoorAccessedDateTime, map => map.MapFrom(src => string.IsNullOrEmpty(src.LastCRPDoorAccessedDateTime) ? (DateTime?)null:DateTime.Parse(src.LastCRPDoorAccessedDateTime)))
                .ForMember(dest => dest.IsOnsite, map => map.MapFrom(src => string.Compare(src.OnsiteStatus,"Onsite",true) == 0 ? true : false));


        }
    }
}
