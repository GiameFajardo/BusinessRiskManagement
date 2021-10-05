using AutoMapper;
using BusinessRiskManagement.Requests;
using Core.Application.DTO;

namespace BusinessRiskManagement.MappingProfiles
{
    public class RequestToApplicationDTO : Profile
    {
        public RequestToApplicationDTO()
        {
            //Organization Mapings
            CreateMap<CreateOrganizationRequest, CompanyDTO>()
                    .ForMember(dest => dest.PhotoURL,
                        opt => opt.MapFrom(
                            src => src.Photo));
            CreateMap<UpdateOrganizationRequest, CompanyDTO>()
                .ForMember(dest => dest.PhotoURL,
                    opt => opt.MapFrom(
                        src => src.Photo));
            // User Mappings
            CreateMap<CreateUserRequest, UserDTO>();
        }
    }
}
