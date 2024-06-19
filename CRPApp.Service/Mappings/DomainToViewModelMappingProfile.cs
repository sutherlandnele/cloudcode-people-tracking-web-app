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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //  Map ONLY those specific fields where it is not clear for Automapper to do the mapping
            CreateMap<CRPOnsiteStatus, OnsiteStatusViewModel>()

                .ForMember(dest => dest.LastCRPDoorAccessedDateTime, map => map.MapFrom(src => src.LastCRPDoorAccessedDateTime.HasValue?((DateTime)(src.LastCRPDoorAccessedDateTime)).ToString("dd/MM/yyyy HH:mm:ss tt"):""))
                .ForMember(dest => dest.OnsiteStatus, map => map.MapFrom(src => (bool)src.IsOnsite ? "Onsite":"Offsite"));
               
        }
    }
}
