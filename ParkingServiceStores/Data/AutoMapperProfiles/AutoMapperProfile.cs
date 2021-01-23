using AutoMapper;
using ParkingServiceStores.Data.DTOModels;
using ParkingServiceStores.Data.Models;

namespace ParkingServiceStores.Data.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarDto, Car>()
                .ForPath(c => c.Owner.Name, opt => opt.MapFrom(c => c.OwnerName))
                .ForPath(c => c.Owner.PhoneNumber, opt => opt.MapFrom(c => c.OwnerPhoneNumber))
                .ForPath(c => c.Owner.Id, opt => opt.MapFrom(c => c.OwnerId)).ReverseMap();
        }
    }
}
