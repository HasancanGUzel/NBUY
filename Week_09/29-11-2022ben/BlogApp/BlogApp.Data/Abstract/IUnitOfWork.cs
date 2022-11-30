using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Abstract
{
    public interface IUnitOfWork: IAsyncDisposable // savechanges işlemi için yaptık yani her işlem sonucu değilde büün işlemler bittiği zaman kaydedicez
    {
        IArticleRepository Articles { get; }// seti yok çünkü bu sadece readonly içine birşey yazamayız
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
