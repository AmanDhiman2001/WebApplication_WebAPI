using AutoMapper;
using WebApplication_WebAPI.Models;
using WebApplication_WebAPI.Models.DTOs;

namespace WebApplication_WebAPI.DTOMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalParkDto, NationalPark>().ReverseMap();
            CreateMap<Trail, TrailDto>().ReverseMap();
        }
    }
}
// database--model--Repository---dto---client
// client---dto--repository---model---database
