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
using System.Text;
using System.Threading.Tasks;

namespace BlogAppServices.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = categoryAddDto.Name,
                Description= categoryAddDto.Description,
                Note=categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedDate = DateTime.Now,
                CreatedByName = createdByName,
                ModifiedDate = DateTime.Now,
                ModifiedByName = createdByName


            }).ContinueWith(k => _unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();// üstteki satrıla aynı şeyi yapıyor

            return new Result(ResultStatus.Success, $"{categoryAddDto.Name}adlı kategori başarıyla eklenmiştir.");
        }

        public Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId,c=>c.Articles);
            if(category!=null)//aranan categori bulunduysa çalışır
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category=category,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
           var categories= await _unitOfWork.Categories.GetAllAsync(null,c=>c.Articles);
            if (categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto 
                {
                    Categories = categories,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategori Bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c=>c.IsDeleted==false,c=>c.Articles);
            if (categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false && c.IsActive == true, c => c.Articles);
            if (categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç kategori bulunamadı", null);
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
