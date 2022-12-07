using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        //biz bu class da web katmanında kaydetme güncelleme vs ne isteniyorsa onla ilgili metotları  buradan bulucaz ve normalde  IUnitOfWork olmasa  data içindeki conctrete içindeki efcore içindeki efCategoryrepository ye ulaşmamız gerekti ama biz ona ulaşmak yerine UnitOfWork içinde tanımladık zaten o yüzden biz buradan UnitOfWork e erişip dolaylı yoldan  efCategoryrepository bunu kullanıcaz yani burada _unitOfWork.Categories diyerek  efCategoryrepository metotlarına ulaşabiliriz buradaki  Categories ise  UnitOfWork içinde var ordan geliyor.
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Generic her sayfada aynı olan metotlar
        public async Task<Category> GetByIdAsync(int id)
        {
           return await _unitOfWork.Categories.GetByIdAsync(id);
        }
        public async Task<List<Category>> GetAllAsync()
        {
           return await _unitOfWork.Categories.GetAllAsync();
        }
        public async Task CreateAsync(Category category)
        {
            await _unitOfWork.Categories.CreateAsync(category);
            await _unitOfWork.SaveAsync();
        }
        public void Delete(Category category)
        {
            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Save();
        }
        public void Update(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }
        #endregion




        #region Kategoriye özgü metotlar
        public Category GetByIdWithProduct()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
