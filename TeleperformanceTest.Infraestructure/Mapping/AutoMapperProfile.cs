using AutoMapper;
using TeleperformanceTest.Core.DTOs;
using TeleperformanceTest.Core.Entities;

namespace TeleperformanceTest.Infrastructure.Mapping
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
