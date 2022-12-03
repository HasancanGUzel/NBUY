using AutoMapper;
using BlogApp.Data.Abstract;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using BlogApp.Services.Abstract;
using BlogApp.Shared.Utilities.Result.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using BlogApp.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogApp.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;//automapper kullanabilmek için

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count>0)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(
                    a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı.", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a=>!a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > 0)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a=>!a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
            if (articles.Count > 0)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç makale bulunamadı.", null);
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)//dışarıdan gelen articleDto verileri Article tipindeki nesneme atıyorum
        {
            var article = _mapper.Map<Article>(articleAddDto);
            #region açıklamaa
            //dışarıdan gelen articleAddDto yu profile yapılarını kullanrak Article tipinde nesneye dönüştür ve article nesnesine at
            //yani burada biz kendimiz eşleştirme yapmak yerine otomatik Article ile ArticleAddDto eşleşti
            #endregion
            article.CreatedByName=createdByName;
            #region açıklama
            // burada articleAddDto da created byname yoktu biz onu kendimiz ekledik
            #endregion
            article.ModifiedByName = createdByName;
            #region açıklma
            //Eğer entiti base içerisinde CreatedDae içi default değer vermemiş olsaydık böyle yapabilirdik.Bunun ikinci bir yolu da profile içinde bu değer verilmelidir.
            //article.CreatedDate= DateTime.Now;
            #endregion
            article.UserId = 1;
            #region acıklama
            //UserId yi şimdilik elle veriyoruz login işlemlerini tamamladığımızda burayı tamamlamış olacağız
            #endregion
            await _unitOfWork.Articles.AddAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} başlıklı makale başarıyla eklenmiştir.");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            
            var result = await _unitOfWork.Articles.GetAsync(a=>a.Id==articleUpdateDto.Id);
            if (result != null)
            {
               var article =_mapper.Map<Article>(articleUpdateDto);
                article.ModifiedByName=modifiedByName;
                await _unitOfWork.Articles.UpdateAsync(article)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} başlıklı kategori başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı.");
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı.");
        }


    }
}
