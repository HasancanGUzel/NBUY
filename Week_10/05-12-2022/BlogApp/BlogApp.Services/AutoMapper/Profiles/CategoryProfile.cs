﻿using AutoMapper;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
                .ForMember(destination => destination.CreatedDate, option => option.MapFrom(x => DateTime.Now));
                    
            CreateMap<CategoryUpdateDto, Category>().
                ForMember(destination => destination.ModifiedDate, option => option.MapFrom(x => DateTime.Now));

        }
    }
}
