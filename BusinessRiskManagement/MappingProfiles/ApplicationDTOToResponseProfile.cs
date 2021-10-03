using AutoMapper;
using BusinessRiskManagement.Responses;
using Core.Application.DTO;

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
        }
    }
}
