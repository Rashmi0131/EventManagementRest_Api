using EventManagementAPICRUD.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagementAPICRUD.DTO_s
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserDTO, User>()
               .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore mapping Id
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash)) // Explicitly map PasswordHash
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Ignore mapping CreatedBy
               .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Ignore mapping UpdatedBy
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore()) // Ignore mapping CreatedDate
               .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore()); // Ignore mapping UpdatedDate

            CreateMap<User, UserDTO>();


            // Event mapping
            CreateMap<EventDTO, Event>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());// Ignore mapping Id
               

            CreateMap<Event, EventDTO>();
        }
    }
}
