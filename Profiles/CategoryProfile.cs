using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VideosAPI_ASP.NetCore_AluraChallenge.Data.DTO;
using VideosAPI_ASP.NetCore_AluraChallenge.Models;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, ReadCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}