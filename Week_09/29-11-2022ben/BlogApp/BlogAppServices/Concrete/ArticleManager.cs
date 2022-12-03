using BlogApp.Data.Abstract;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using BlogApp.Shared.Utilities.Result.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using BlogApp.Shared.Utilities.Result.Concrete;
using BlogAppServices.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppServices.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            await _unitOfWork.Articles.AddAsync(new Article
            {
                Title = articleAddDto.Title,  // Article entitimizden nesne üretiyoruz ve bu nesnelere  articleAddDto dan gelen verileri atıyoruz
                Content = articleAddDto.Content,
                Thumbnail = articleAddDto.Thumbnail,
                Date = articleAddDto.Date,
                SeoAuthor = articleAddDto.SeoAuthor,
                SeoDescription = articleAddDto.SeoDescription,
                SeoTags = articleAddDto.SeoTags,
                IsActive = articleAddDto.IsActive,
                CategoryId = articleAddDto.CategoryId,
                CreatedDate = DateTime.Now,
                CreatedByName = createdByName,
                ModifiedDate = DateTime.Now,
                ModifiedByName = createdByName,
                IsDeleted = false

            }).ContinueWith(k => _unitOfWork.SaveAsync()); // kaydediyoruz unitofwork de kayıt işlemi için taslak oluşturmuştuk
            //await _unitOfWork.SaveAsync();// üstteki satrıla aynı şeyi yapıyor

            return new Result(ResultStatus.Success, $"{articleAddDto.Title}başlıklı makale başarıyla yüklenmiştir."); //geri değer döndürüyoruz result tipinde nesne üretiyoruz ve buraya add yani ekleme ile ilgili mesajları veriyoruz. burada error mesajı vermeye gerek yok çünkü buraya geldiyse başarılıdır.
        }

        public Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article= await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.Category);
            if (article != null)//aranan article bulunduysa çalışır
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
           var articles=await _unitOfWork.Articles.GetAllAsync(null, a => a.Category);
            if (articles.Count>0)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "makale Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(c => c.IsDeleted == false, c => c.Category);
            if (articles.Count > 0)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "makale Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(c => c.IsDeleted == false && c.IsActive == true, c => c.Category);
            if (articles.Count > 0)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç kategori bulunamadı", null);
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
