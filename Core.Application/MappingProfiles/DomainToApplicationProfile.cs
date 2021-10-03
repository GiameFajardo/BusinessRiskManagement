using AutoMapper;
using Core.Application.DTO;
using Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.MappingProfiles
{
    public class DomainToApplicationProfile: Profile
    {
        public DomainToApplicationProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ForMember(dest => dest.PhotoURL,
                    opt => opt.MapFrom(src => src.Photo));
                //.ForMember(dest => dest.PhotoFile,
                //    opt=> opt.Ignore());
        }
    }
}
