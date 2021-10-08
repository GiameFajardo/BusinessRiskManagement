using AutoMapper;
using BusinessRiskManagement.Responses;
using Core.Application.DTO;
using Core.Domain.Model;

namespace BusinessRiskManagement.MappingProfiles
{
    public class ApplicationDTOToResponseProfile : Profile
    {
        public ApplicationDTOToResponseProfile()
        {
            CreateMap<CompanyDTO, OrganizationResponse>()
                .ForMember(dest => dest.Photo,
                    opt => opt.MapFrom(src =>
                        src.PhotoURL
                    ));

            CreateMap<UserDTO, UserResponse>()
                .ReverseMap();

            CreateMap<UserDTO, ApplicationUser>()
                .ReverseMap();
            CreateMap<DepartmentDTO, DepartmentResponse>()
                .ReverseMap();
        }
    }
}
