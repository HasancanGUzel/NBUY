using BlogApp.Shared.Utilities.Result.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Utilities.Result.Concrete
{
    public class Result : IResult
    {

        public Result(ResultStatus resultStatus)
        {
            ResultStatus=resultStatus; //burada propteries olan ResultStatus e dışarıdan gelen veriyi attık
        }

        public Result(ResultStatus resultStatus,string message)
        {
            ResultStatus = resultStatus;//burada propteries olan ResultStatus edışarıdan gelen veriyi attık
            Message =message;// burada propteries olan Message e dışarıdan gelen veriyi attık
        }

        public Result(ResultStatus resultStatus, string message,Exception exception)
        {
            ResultStatus = resultStatus;//burada propteries olan ResultStatus edışarıdan gelen veriyi attık
            Message = message;// burada propteries olan Message e dışarıdan gelen veriyi attık
            Exception = exception;// burada propteries olan Exception e dışarıdan gelen veriyi attık
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}

//New Result(); böyle kullanmak istemiyoruz

//böyle kullanmak isteriz
//New Result(ResultStatus.Success);
//New Result(ResultStatus.Success,"Kyaıt işlemi başarılı");
//New Result(ResultStatus.Success,"İşlem tamamlandı",new throw.ImplementNotException);