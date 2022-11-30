using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Utilities.Result.Abstract
{
    public interface IDataResult<out T>:IResult //out list collection vs döndürülebilir anlamına geliyor
    {
        public T Data { get;}//new DataResult<Category> (ResultStatus.Success,category)
        //new DataResult<IList<Category>>(ResultStatus.Success,categries)
        //new DataResult<IList<Category>>(ResultStatus.Success,"İŞLEM BAŞARILI",categries)

    }
}
