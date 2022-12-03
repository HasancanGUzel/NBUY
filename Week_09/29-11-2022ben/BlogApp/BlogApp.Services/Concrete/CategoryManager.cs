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
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles);
            if (category!=null)//aranan kategori bulunduysa
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null,c=>c.Articles);
            if (categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories=categories,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c=>c.Articles);
            if (categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories=categories,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive, c=>c.Articles);
            if (categories.Count>0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories=categories,
                    ResultStatus=ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç kategori bulunamadı.", null);
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category()
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note = categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }).ContinueWith(t => _unitOfWork.SaveAsync());

            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir.");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if (category != null)
            {
                category.Name = categoryUpdateDto.Name;
                category.Description = categoryUpdateDto.Description;
                category.Note = categoryUpdateDto.Note;
                category.IsActive = categoryUpdateDto.IsActive;
                category.IsDeleted = categoryUpdateDto.IsDeleted;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı");
        }

        public Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
