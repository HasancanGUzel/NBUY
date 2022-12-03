using AutoMapper;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services.AutoMapper.Profiles
{
    public class ArticleProfile:Profile//automapper eklemek için auto mapper ise article managerda eşlemek için
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>()//burada automapper işlemi oluyor yani article manager içindeki add metodunun içindeki verileri bizim eşlememiz yerine otomatik eşliyor.
                .ForMember(dest => dest.CreatedDate, option => option.MapFrom(x =>DateTime.Now));//her bir üye için zamanı veriyoruz.
            CreateMap<ArticleUpdateDto, Article>() // dest veya destination farketmez isim verdik
                .ForMember(destination=>destination.ModifiedByName,option=>option.MapFrom(x=>DateTime.Now));
        }
    }
}
