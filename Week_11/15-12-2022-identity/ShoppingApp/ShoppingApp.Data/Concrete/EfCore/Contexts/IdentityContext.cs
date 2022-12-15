using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete.EfCore.Contexts
{
    public class IdentityContext:IdentityDbContext<User>//Oluşturuğumuz  IdentityContext te  ıdentitynin otomatik oluşan IdentityDbContext içine oluşturduğumuz entity de atarak miras aldırdık
    {
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {

        }
    }
}
