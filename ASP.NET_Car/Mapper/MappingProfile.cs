using ASP.NET_Car.DtoModels;
using ASP.NET_Car.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cars, CarsDto>().ReverseMap();
        }
    }
}
