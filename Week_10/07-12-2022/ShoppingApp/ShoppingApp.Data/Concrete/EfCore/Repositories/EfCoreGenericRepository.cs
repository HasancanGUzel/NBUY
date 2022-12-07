using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete.EfCore.Repositories
{
    
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, // bundan miras alan class lar new lenebilir olmalı Tentity ve class olmalı
        new()
    {
        private readonly DbContext _context;// bunun içini  EfCoreGenericRepository bunu başka class larda  kullandığımız  zaman kullanıcaz

        public EfCoreGenericRepository(DbContext context) // buda constructor 
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);//burda  dışarıdan gelen TEntity(category products) veriyi yani (context.product) olarak algılıyor ve entity dışarıdan gelen veriyi alarak addAsync yapıyoruz.
            //buradaki AddAsync kodları bizim yazdığımız değil programdan alıyoruz
        }

        public void  Delete(TEntity entity)
        {
             _context.Set<TEntity>().Remove(entity);// dışarıdan gelen veriyi(entity) alıp siliyor
            //buradaki Remove kodları bizim yazdığımız değil programdan alıyoruz
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
            //buradaki ToListAsync kodları bizim yazdığımız değil programdan alıyoruz

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
            //buradaki FindAsync kodları bizim yazdığımız değil programdan alıyoruz

        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            //buradaki Update kodları bizim yazdığımız değil programdan alıyoruz

            //_context.Entry(entity).State = EntityState.Modified;// bu satırda üstteki gibi güncelleme işlemi yapar
        }
    }
}
