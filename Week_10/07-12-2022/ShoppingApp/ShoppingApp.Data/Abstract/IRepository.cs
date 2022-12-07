using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IRepository<T> // bütün entitylerimizde geçerli olmasını istediğimiz metotları hazırlıyoruz generic yapıda 
    {
        Task<T> GetByIdAsync(int id);// asenkron yaptık ve asenkron olduğu için async ismini koyduk bu metot ise ıd ye göre entity getiricek
        Task<List<T>> GetAllAsync();//ilgili entity ile ilgili tüm kayıtları getiricek
        Task CreateAsync(T entity);//yeni kayıt yaratacak T türünde yani product category vs entity de değişken 
         void Update(T entity);//kayıt güncelleyecek
         void Delete(T entity);//kaıt silecek
        
    }
}
