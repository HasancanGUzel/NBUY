using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EntityFramework.Context;
using BlogApp.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork  // savechanges işlemi için yaptık yani her işlem sonucu değilde büün işlemler bittiği zaman kaydedicez
    {
        private readonly BlogAppContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfRoleRepository _roleRepository;
        private EfUserRepository _userRepository;

        public UnitOfWork(BlogAppContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context); // _articleRepository bu yoksa veya null ise soru işaretinden sonrakileri yapıcak

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);

        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); // save changes işlemi burada gerçekleşiyor ama zamanını vermedik daha hangi koşullarda kaydedicek daha belirlemedik
        }
    }
}
