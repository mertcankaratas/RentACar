using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
   public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string RentalAdded = "Kiralama Eklendi";

        public static string FailedCarAdded = "Araba Eklenemedi";
        public static string FailedColorAdded = "Renk Eklenemedi";
        public static string FailedBrandAdded = "Marka Eklenemedi";
        public static string FailedUserAdded = "Kullanıcı Eklenemedi";
        public static string FailedCustomerAdded = "Müşteri Eklenemedi";
        public static string FailedRentalAdded = "Kiralama Eklenemedi";

        public static string CarUpdated = "Araba Güncellendi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string RentalUpdated = "Kiralama Güncellendi";

        public static string CarDeleted = "Araba Silindi";
        public static string ColorDeleted = "Renk Silindi";
        public static string BrandDeleted = "Marka Silindi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string RentalDeleted = "Kiralama Silindi";
        
        public static string CarListed = "Arabalar Listelendi";
        public static string ColorListed = "Renkler Listelendi";
        public static string BrandListed = "Markalar Listelendi";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string CustomerListed = "Müşteriler Listelendi";
        public static string RentalListed = "Kiralamalar Listelendi";
        public static string CarImageAdded="Araba resmi eklendi ";
        public static string CarImageDeleted="Araba resmi silindi";
        public static string CarImageUpdated="Araba resmi güncellendi";
        public static string CarImageListed="Araba resimleri listelendi";
        public static string CarImageLimitExceded="Araba resim Limiti aşıldı";
        public static string CarNotFound="Araba resmi bulunamadı";
        public static string AuthorizationDenied ="Yetkiniz bulunmamaktadır";
        public static string UserRegistered="kullanıcı kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola Hatalı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UserAlreadyExists= "Kullanıcı Mevcut";
        public static string AccessTokenCreated ="Accestoken Yaratıldı";
    }
}
