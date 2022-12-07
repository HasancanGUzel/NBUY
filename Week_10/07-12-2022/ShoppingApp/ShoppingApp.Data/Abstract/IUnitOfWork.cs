using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IUnitOfWork:IDisposable // IDisposable burada işim bittiği zaman yaşayan olmasın silinsin diye
        // merkezi bir yerden repository lere erişmek için save yapabilmek için
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task SaveAsync();
        void Save();// bunu category manager daki update ve delete için yaptık çünkü onlar asenkron değildi

    }
}
