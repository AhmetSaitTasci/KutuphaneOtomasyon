# Kütüphane Otomasyon Projesi

Bu proje, kütüphane içerisindeki kitapları, üyeleri ve kitap ödünç alma/iade işlemlerini takip etmek için yapılmış bir otomasyon projesidir. Uygulama C# Windows Forms ile geliştirilmiştir.

Veritabanı işlemleri için C# tarafında Entity Framework kullandık. Projede ilişkili veritabanı yapısı bulunmaktadır. Kitaplar, üyeler ve ödünç kayıtları birbirine bağlı şekilde çalışmaktadır.

## Projenin Özellikleri ve Kullanımı

Uygulama içerisinde tek ana ekran üzerinde birkaç temel bölüm bulunmaktadır. Bu bölümler kitap işlemleri, üye işlemleri ve ödünç işlemleri olarak ayrılmıştır.

## 1. Kitap İşlemleri

Bu bölümde kütüphanedeki kitapların bilgileri tutulmaktadır.

Kitaplar için şu bilgiler kaydedilmektedir:

- Kitap adı
- Yazar
- Yayınevi
- Basım yılı
- ISBN
- Raf no
- Stok adedi

Bu bölümde veritabanındaki kitaplar DataGridView üzerinde listelenmektedir. Yeni kitap eklemek için kitap bilgileri girilip Kitap Ekle butonuna basılır. Böylece kitap veritabanına kaydedilir ve liste güncellenir.

Ayrıca seçilen kitap silinebilmektedir. Kitap silinirken o kitaba ait ödünç kayıtları varsa önce bu kayıtlar silinir, daha sonra kitap silinir.

Kitap arama özelliği de ekledik. Kitap adı, yazar veya ISBN bilgisine göre arama yapılabilmektedir. Bu işlem LINQ sorguları ile yapılmıştır.

## 2. Üye İşlemleri

Bu bölümde kütüphaneden kitap alabilecek üyelerin bilgileri tutulmaktadır.

Üyeler için şu bilgiler kaydedilmektedir:

- Ad soyad
- Telefon
- Email
- Kayıt tarihi

Yeni üye eklemek için ad soyad, telefon ve email bilgileri girilip Üye Ekle butonuna basılır. Eklenen üyeler DataGridView üzerinde listelenmektedir.

Ayrıca seçilen üye sistemden silinebilmektedir. Eğer üyeye ait ödünç kayıtları varsa, önce o üyeye ait ödünç kayıtları silinir ve ardından üye kaydı silinir.

## 3. Ödünç İşlemleri

Projenin ilişkili tabloları kullandığı en önemli bölüm ödünç işlemleri bölümüdür.

Bu bölümde kitap ve üye seçimi ComboBox üzerinden yapılmaktadır. ComboBox içerisinde kullanıcıya kitap adı ve üye adı gösterilir. Ancak arka planda bu kayıtların ID bilgileri tutulur.

Bu işlem için ComboBox kontrollerinde DisplayMember ve ValueMember özelliklerini kullandık.

Kitap ödünç verme işleminde kitap seçilir, üye seçilir, alış tarihi belirlenir, teslim tarihi belirlenir ve Ödünç Ver butonuna basılır.

Kitap ödünç verildiğinde kitabın stok adedi otomatik olarak 1 azalır.

İade alma işleminde ise ödünç kayıtları tablosundan ilgili kayıt seçilir ve İade Al butonuna basılır. Kitap iade edildiğinde iade tarihi otomatik olarak bugünün tarihi yapılır ve kitabın stok adedi 1 artırılır.

## 4. Geciken Kitaplar

Projeye geciken kitapları gösterme özelliği de ekledik.

Teslim tarihi geçmiş olan ve hâlâ iade edilmemiş kitaplar Gecikenleri Göster butonu ile listelenmektedir. Bu sayede hangi üyenin hangi kitabı zamanında teslim etmediği görülebilir.

## Veritabanı Yapısı

Projede 3 temel tablo bulunmaktadır.

## Kitaplar Tablosu

Kitap bilgilerini tutar.

- Id
- KitapAdi
- Yazar
- Yayinevi
- BasimYili
- Isbn
- RafNo
- StokAdedi

## Uyeler Tablosu

Üye bilgilerini tutar.

- Id
- AdSoyad
- Telefon
- Email
- KayitTarihi

## Oduncler Tablosu

Hangi üyenin hangi kitabı aldığını tutar.

- Id
- KitapId
- UyeId
- AlisTarihi
- TeslimEdilecekTarih
- IadeTarihi

## Tablolar Arasındaki İlişki

Projede kitaplar, üyeler ve ödünç kayıtları arasında ilişkili yapı kullandık.

Bir üye birden fazla kitap ödünç alabilir. Bir kitap da farklı zamanlarda farklı üyelere ödünç verilebilir.

Bu yüzden Oduncler tablosu, Kitaplar ve Uyeler tabloları ile ilişkilidir.

İlişki yapısı şu şekildedir:

```text
Uyeler  ---- Oduncler ---- Kitaplar

Oduncler tablosunda hem KitapId hem de UyeId tutulmaktadır. Böylece hangi üyenin hangi kitabı aldığı takip edilebilmektedir.

Kullanılan Teknolojiler
C#
Windows Forms
Entity Framework
SQL Server LocalDB
LINQ
DataGridView
ComboBox
DateTimePicker
Kullanılan Temel Kontroller

Projede kullandığımız başlıca Windows Forms kontrolleri şunlardır:

TextBox
Label
Button
DataGridView
ComboBox
DateTimePicker
GroupBox
MessageBox
Uygulamanın Çalışma Mantığı

Uygulama açıldığında veritabanındaki kitaplar, üyeler ve ödünç kayıtları listelenir.

Kitap ekleme bölümünden yeni kitap eklenebilir.

Üye ekleme bölümünden yeni üye eklenebilir.

Ödünç işlemleri bölümünden seçilen kitap seçilen üyeye ödünç verilebilir.

Kitap ödünç verildiğinde stok azalır.

Kitap iade edildiğinde stok tekrar artar.

Teslim tarihi geçmiş ve iade edilmemiş kitaplar geciken kitaplar olarak gösterilir.

Uygulamadan Ekran Görüntüleri
Ana Ekran
<img width="1746" height="855" alt="Ekran görüntüsü 2026-05-27 000552" src="https://github.com/user-attachments/assets/097373b4-19d3-4d79-9bca-5bf8b70bf275" />
<img width="1734" height="853" alt="Ekran görüntüsü 2026-05-27 000730" src="https://github.com/user-attachments/assets/9feb5456-31c4-4e20-97a4-2a52647e59a3" />

Burada kitap ekleme, üye ekleme, ödünç verme ve listeleme işlemleri aynı ekran üzerinde gösterilmektedir.

Kitap Listeleme ve Arama
<img width="1739" height="983" alt="Ekran görüntüsü 2026-05-27 000932" src="https://github.com/user-attachments/assets/a4a88a37-f77e-4b41-8b83-39582357fb1b" />
<img width="1725" height="850" alt="Ekran görüntüsü 2026-05-27 000901" src="https://github.com/user-attachments/assets/a76e308b-8539-4406-b748-483a7168ce8c" />
Bu ekranda kitaplar listelenmekte ve kitap adı, yazar veya ISBN bilgisine göre arama yapılabilmektedir.

Üye Listeleme
<img width="1729" height="849" alt="Ekran görüntüsü 2026-05-27 000836" src="https://github.com/user-attachments/assets/65dc690f-90f8-45b1-9b7c-de26e61dc53a" />
Bu bölümde sisteme kayıtlı üyeler listelenmektedir.

Ödünç Kayıtları
<img width="1730" height="852" alt="Ekran görüntüsü 2026-05-27 001016" src="https://github.com/user-attachments/assets/d49d837d-7f41-447c-84d0-8c0ea97cc052" />

Bu bölümde hangi kitabın hangi üye tarafından alındığı, alış tarihi, teslim tarihi, iade tarihi ve durum bilgisi gösterilmektedir.

Geciken Kitaplar
<img width="1729" height="852" alt="Ekran görüntüsü 2026-05-27 001031" src="https://github.com/user-attachments/assets/81a7cba8-f8cb-42cf-b39c-08fffbd383e5" />

Bu bölümde teslim tarihi geçmiş ve iade edilmemiş kitaplar listelenmektedir.

Sonuç

Bu proje ile C# Windows Forms üzerinde Entity Framework kullanarak basit bir kütüphane otomasyonu geliştirdik.

Proje sayesinde kitap stok takibi, üye kaydı, kitap ödünç verme, iade alma, kitap arama ve geciken kitapları listeleme işlemleri yapılabilmektedir.

İlişkili veritabanı yapısı sayesinde kitaplar, üyeler ve ödünç işlemleri birbirine bağlı olarak çalışmaktadır.
