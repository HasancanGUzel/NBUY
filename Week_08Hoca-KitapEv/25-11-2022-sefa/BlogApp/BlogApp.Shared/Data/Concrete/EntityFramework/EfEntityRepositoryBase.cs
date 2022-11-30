using BlogApp.Shared.Data.Abstract;
using BlogApp.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> 
        where TEntity : class, // T class olmalı
        IEntity, // T IEntity olmalı o yüzden shared da IEntity  oluşturduk ve içi boş miras verdirdik
        new()  // T new olarak yaratılabilmeli
        // bunlar olmasa da olur hata vermez ama bu işlemler gerektiğinde sorun çıkarabilir.
    {
        private readonly DbContext _context;
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity); //asenkron method(async)
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });  //asenkron olarak çalışmasını sağlayacak. çünkü metotları yok.
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(()=> { _context.Set<TEntity>().Update(entity); }); //asenkron olarak çalışmasını sağlayacak. çünkü metotları yok.
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            //Burada contexte erişip hangi entity ile çalışcaksak o entityi IQueryable olarak alıyoruz ki sonra bunun arkasına where, include gibi yapıları duurma göre ekleyebiliriz.
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate!=null) //predicate dediğimiz kısım null değilse, bu bir koşul belirtilmiş olur. dolayısıyla bu durumda o koşulu(predicate) if içinde where ile query üzerine ekliyoruz. Eğer predicate null ise query üzerine where ile ilgili bir şey eklememize gerek yok
            {
                query = query.Where(predicate);// 
            }
            if (includeProperties.Any()) // dizinin içinde include yapılan kısım varmı varsa alttaki döngüye girer ve querye eklenir. ki  her eleman bir include taşıyor. burası da bittiğinde artık ToList yapılabilir halde bir query elimizde olacak. 
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }
        //Article article = repositoryArticle.GetAsync(x => x.CategoryId == 12, y => y.User, z => z.Comments)
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(); //sonucun ilkini getirir. birden fazla da olabilir.
            // return await query.SingleOrDefaultAsync(); // sadece bir tane sonuç olduğunda getirir. sadece tek kayıt vardır.
        }

    }
}
