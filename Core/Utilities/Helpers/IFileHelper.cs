using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        //IFormFile: HttpRequest ile gönderilen bir dosyayı temsil eder.
        //string root: Bu dosyanın kaydedileceği adresi tutar.


        IResult Upload(IFormFile file, string root);
        IResult Delete(string filePath);
        IResult Update(IFormFile file, string filePath, string root);

    }
}
