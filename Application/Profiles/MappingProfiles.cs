using Application.Dto.Authentication.Dto;
using AutoMapper;
using Domain.Entites;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RegisterUserDto, ApplicationUser>().ReverseMap();
            CreateMap<RegisterResponseDto, ApplicationUser>().ReverseMap();
            

        }
    }
}
