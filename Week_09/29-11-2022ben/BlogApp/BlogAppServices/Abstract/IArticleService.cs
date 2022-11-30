using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using BlogApp.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppServices.Abstract
{
    public interface IArticleService
    {




        //Get,GetAll,Add,Delete,Update,,HardDelete,GetAllByNonDeleted,GetAllByNonDeletedAndActive,GetAllByCategory(categoryId)


        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);

        //uygulama içinde işime yarayan article daki propertiesları taşımak için kullanıcaz bütün propertieslaır getirmicez hangisi kullanıcaksak onları kullanıcaz yani add için beli şeyler olur güncelleme için farklı şeyler vs.
        Task<IResult> Add(ArticleAddDto articleAddDto,string createdByName);  //ArticleAddDto adında class oluşturduk ve orada add için kullanacağımız propteriesları topladık vurada ona göre kullanıcaz

        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);


        Task<IResult> Delete(int categoryId, string modifiedByName);//silinmesini istediğimiz ıd yi tutucak
        Task<IResult> HardDelete(int categoryId);
    }
}
