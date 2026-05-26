using System;

namespace KutuphaneOtomasyon.Models
{
    public class Odunc
    {
        public int Id { get; set; }

        public int KitapId { get; set; }

        public int UyeId { get; set; }

        public DateTime AlisTarihi { get; set; }

        public DateTime TeslimEdilecekTarih { get; set; }

        public DateTime? IadeTarihi { get; set; }

        public virtual Kitap Kitap { get; set; }

        public virtual Uye Uye { get; set; }
    }
}