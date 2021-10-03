using AutoMapper;
using BusinessRiskManagement.Requests;
using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.MappingProfiles
{
    public class RequestToApplicationDTO: Profile
    {
        public RequestToApplicationDTO()
        {
            CreateMap<CreateOrganizationRequest, CompanyDTO>()
                .ForMember(dest=> dest.PhotoURL,
                    opt=> opt.MapFrom(
                        src => src.Photo));
            CreateMap<UpdateOrganizationRequest, CompanyDTO>()
                .ForMember(dest => dest.PhotoURL,
                    opt => opt.MapFrom(
                        src => src.Photo));
        }
    }
}
