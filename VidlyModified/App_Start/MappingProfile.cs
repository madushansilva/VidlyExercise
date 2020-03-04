using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyModified.Dtos;
using VidlyModified.Models;
using AutoMapper;

namespace VidlyModified.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MemberShipType,MemberShipTypeDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<MovieDto, Movie>();

        }

    }
}