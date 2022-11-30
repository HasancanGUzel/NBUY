using BlogApp.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Data.Abstract
{
    public interface IEntityRepository<T> // generic yapı
        where T : class, 
        IEntity, 
        new() 
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //Not1, Not2
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includeProperties);  // Not3
        Task AddAsync(T entity); //entity değişken adı
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}

/*
    Not1;
    ******
    *Örneğin Idsi 12 olan Article'ı getirmek istiyoruz.
    *var article = repository.GetAsync(x=>x.Id==12)
    *User user = repositoryUser.GetAsync(x=>x.Name == "enginniyazi")
*/

/*
    Not2;
    ******
    *Örneğin Idsi 12 olan Article'ı User ve commentleri ile birlikte getirmek istiyoruz
    *Article article = repositoryArticle.GetAsync(x=>x.Id==12, y=>y.User, z=>z.Comments) // dizi gibi
*/
/*
    Not3
    ******
    *Örneğin tüm Article'ları listelemek istiyoruz.
    * var articles = repositoryArticle.GetAllAsync();
    * 
    * Örneğin dotnet kategorisindeki tğm articleları listelemek istiyoruz.
    * var articles = repositoryArticle.GetAllAsync(a=>a.Category.Name=="DotNet", c=>c.Category(Category))
    * 
    * Örneğin Id'si 12 olan article ın yorumlarını getimek istiyoruz.
    * var comments = repositoryComment.GetAllAsync(c=>c.ArticleId==12)
*/