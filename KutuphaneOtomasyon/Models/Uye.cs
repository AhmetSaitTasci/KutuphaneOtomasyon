using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyon.Models
{
    public class Uye
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public DateTime KayitTarihi { get; set; }

        public virtual ICollection<Odunc> Oduncler { get; set; }

        public Uye()
        {
            Oduncler = new List<Odunc>();
        }
    }
}