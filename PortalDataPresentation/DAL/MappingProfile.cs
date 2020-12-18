using AutoMapper;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalDataPresentation.DAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MeasurementData, MeasurementDataViewModel>();
            CreateMap<MeasurementDataViewModel, MeasurementData>();
            CreateMap<PostMeasurementsVM, MeasurementData>();
        }
    }
}