using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string AddSuccessful="Ekleme Başarılı";
        public static string AddFailed = "Ekleme Başarısız";
        public static string DeleteSuccessful = "Silme başarılı..";
        public static string InsertFailed = "Ekleme Başarısız..";
        public static string UpdateFailed = "Güncelleme başarısız..";
        public static string UpdateSuccessful = "Güncelleme başarılı..";
        public static string DeleteFailed = "Silme Başarısız";
        public static string ListingSuccessful = "Listeleme başarılı";
        public static string PriceIsWrong = "Fiyat hatalı!!";
        public static string WrongName = "Hatalı isim";
        public static string ListingFailed = "Listeleme Başarısız";
        public static string CeheckProductPrice="Bu fiyat aralığında ürün bulunamadı";
        public static string CarImageLimit="Resim sayısı 5 taneden fazla olamaz.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı Sayfaya yönlendiriliyorsunuz";
        public static string UserAlreadyExists = "Zaten bu kullanıcı mevcut";
        public static string UserRegistered = "Kayıt Başarılı.";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
