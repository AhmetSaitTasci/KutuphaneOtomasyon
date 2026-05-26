using KutuphaneOtomasyon.Data;
using KutuphaneOtomasyon.Models;
using KutuphaneOtomasyon.Models;
using System;
using System.Data.Entity;

namespace KutuphaneOtomasyon.Data
{
    public class KutuphaneInitializer : CreateDatabaseIfNotExists<KutuphaneContext>
    {
        protected override void Seed(KutuphaneContext context)
        {
            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Nutuk",
                Yazar = "Mustafa Kemal Atatürk",
                Yayinevi = "Türk Tarih Kurumu",
                BasimYili = 1927,
                Isbn = "9789751600001",
                RafNo = "A-1",
                StokAdedi = 3
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Kürk Mantolu Madonna",
                Yazar = "Sabahattin Ali",
                Yayinevi = "Yapı Kredi Yayınları",
                BasimYili = 1943,
                Isbn = "9789753638029",
                RafNo = "A-2",
                StokAdedi = 5
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Suç ve Ceza",
                Yazar = "Fyodor Dostoyevski",
                Yayinevi = "Can Yayınları",
                BasimYili = 1866,
                Isbn = "9789750719387",
                RafNo = "A-3",
                StokAdedi = 4
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Sefiller",
                Yazar = "Victor Hugo",
                Yayinevi = "İş Bankası Kültür Yayınları",
                BasimYili = 1862,
                Isbn = "9786053600001",
                RafNo = "A-4",
                StokAdedi = 3
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "1984",
                Yazar = "George Orwell",
                Yayinevi = "Can Yayınları",
                BasimYili = 1949,
                Isbn = "9789750718533",
                RafNo = "B-1",
                StokAdedi = 6
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Hayvan Çiftliği",
                Yazar = "George Orwell",
                Yayinevi = "Can Yayınları",
                BasimYili = 1945,
                Isbn = "9789750719388",
                RafNo = "B-2",
                StokAdedi = 5
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Satranç",
                Yazar = "Stefan Zweig",
                Yayinevi = "Türkiye İş Bankası Kültür Yayınları",
                BasimYili = 1943,
                Isbn = "9786053320001",
                RafNo = "B-3",
                StokAdedi = 4
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Simyacı",
                Yazar = "Paulo Coelho",
                Yayinevi = "Can Yayınları",
                BasimYili = 1988,
                Isbn = "9789750726439",
                RafNo = "B-4",
                StokAdedi = 3
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Kuyucaklı Yusuf",
                Yazar = "Sabahattin Ali",
                Yayinevi = "Yapı Kredi Yayınları",
                BasimYili = 1937,
                Isbn = "9789753638028",
                RafNo = "C-1",
                StokAdedi = 4
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "İnce Memed",
                Yazar = "Yaşar Kemal",
                Yayinevi = "Yapı Kredi Yayınları",
                BasimYili = 1955,
                Isbn = "9789750807144",
                RafNo = "C-2",
                StokAdedi = 3
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Tutunamayanlar",
                Yazar = "Oğuz Atay",
                Yayinevi = "İletişim Yayınları",
                BasimYili = 1972,
                Isbn = "9789754700113",
                RafNo = "C-3",
                StokAdedi = 2
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Çalıkuşu",
                Yazar = "Reşat Nuri Güntekin",
                Yayinevi = "İnkılap Kitabevi",
                BasimYili = 1922,
                Isbn = "9789751020001",
                RafNo = "C-4",
                StokAdedi = 4
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Beyaz Diş",
                Yazar = "Jack London",
                Yayinevi = "İş Bankası Kültür Yayınları",
                BasimYili = 1906,
                Isbn = "9786052950001",
                RafNo = "D-1",
                StokAdedi = 5
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Martin Eden",
                Yazar = "Jack London",
                Yayinevi = "İş Bankası Kültür Yayınları",
                BasimYili = 1909,
                Isbn = "9786052950002",
                RafNo = "D-2",
                StokAdedi = 3
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Dönüşüm",
                Yazar = "Franz Kafka",
                Yayinevi = "Can Yayınları",
                BasimYili = 1915,
                Isbn = "9789750720001",
                RafNo = "D-3",
                StokAdedi = 5
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Şeker Portakalı",
                Yazar = "José Mauro de Vasconcelos",
                Yayinevi = "Can Yayınları",
                BasimYili = 1968,
                Isbn = "9789750738609",
                RafNo = "D-4",
                StokAdedi = 4
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Bilinçaltının Gücü",
                Yazar = "Joseph Murphy",
                Yayinevi = "Diyojen Yayıncılık",
                BasimYili = 1963,
                Isbn = "9786050000001",
                RafNo = "E-1",
                StokAdedi = 2
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Küçük Prens",
                Yazar = "Antoine de Saint-Exupéry",
                Yayinevi = "Can Çocuk",
                BasimYili = 1943,
                Isbn = "9789750724436",
                RafNo = "E-2",
                StokAdedi = 6
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Fahrenheit 451",
                Yazar = "Ray Bradbury",
                Yayinevi = "İthaki Yayınları",
                BasimYili = 1953,
                Isbn = "9786053750001",
                RafNo = "E-3",
                StokAdedi = 3
            });

            context.Kitaplar.Add(new Kitap
            {
                KitapAdi = "Cesur Yeni Dünya",
                Yazar = "Aldous Huxley",
                Yayinevi = "İthaki Yayınları",
                BasimYili = 1932,
                Isbn = "9786053750002",
                RafNo = "E-4",
                StokAdedi = 3
            });

            context.Uyeler.Add(new Uye
            {
                AdSoyad = "Ahmet Yılmaz",
                Telefon = "05551234567",
                Email = "ahmet@mail.com",
                KayitTarihi = DateTime.Today
            });

            context.Uyeler.Add(new Uye
            {
                AdSoyad = "Ayşe Demir",
                Telefon = "05559876543",
                Email = "ayse@mail.com",
                KayitTarihi = DateTime.Today
            });

            context.Uyeler.Add(new Uye
            {
                AdSoyad = "Mehmet Kaya",
                Telefon = "05554443322",
                Email = "mehmet@mail.com",
                KayitTarihi = DateTime.Today
            });

            context.Uyeler.Add(new Uye
            {
                AdSoyad = "Zeynep Çelik",
                Telefon = "05556667788",
                Email = "zeynep@mail.com",
                KayitTarihi = DateTime.Today
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}