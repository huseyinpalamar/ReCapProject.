using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            var result = CheckIfFileExists(filePath);
            if (!result.Success)
            {
                return result;
            }
             File.Delete(filePath);
            return new SuccessResult();
        }

        public IResult Upload(IFormFile file, string root)
        {
            if (file.Length>0)

            {
                // klasor var mı yokmu?.
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                 
                // benzersiz isim
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                CreateFile(root+fileName,file);
                return new SuccessResult(fileName);
            }

             return new ErrorResult();

        }
        public IResult Update(IFormFile file, string filePath, string root)
        {
            var resultOfDelete=Delete(filePath);
            if (!resultOfDelete.Success)
            {
                return resultOfDelete;
            }
            var resultOfUpdate= Upload(file, root); 
            if (!resultOfUpdate.Success)
            {
                return resultOfUpdate;
            }
            return new SuccessResult("Güncelleme İşlemi Başarılı");
        }



        private void CreateFile(string directory, IFormFile file)
        {
            //Yeni bir dosya oluşturulur ve eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream); //Oluşturduğumuz dosyanın içine resmi kopyaladık.
                fileStream.Flush(); //Tampondaki bilgilerin boşaltılmasını ve stream dosyasının güncellenmesini sağlar.
            }
        }

        private IResult  CheckIfFileExists(string filePath)
        {
            if(File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya bulunamadı");
        }

        
    }
}
