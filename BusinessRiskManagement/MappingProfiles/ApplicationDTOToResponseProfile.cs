using AutoMapper;
using BusinessRiskManagement.Requests;
using BusinessRiskManagement.Responses;
using BusinessRiskManagement.Responses.Department;
using BusinessRiskManagement.Responses.WorkingArea;
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

            CreateMap<UserDTO, UpdateUserRequest>()
                .ReverseMap();
            CreateMap<UserDTO, ApplicationUser>()
                .ReverseMap();
            CreateMap<DepartmentDTO, DepartmentResponse>()
                .ReverseMap();

            CreateMap<WorkinAreaDTO, WorkingAreaResponse>()
                //.ForMember(dest => dest.Users,
                //    opt => opt.MapFrom(src => src.Users.Select(x => x.ApplicationUser))
                //)
                .ReverseMap();
        }
    }
}
