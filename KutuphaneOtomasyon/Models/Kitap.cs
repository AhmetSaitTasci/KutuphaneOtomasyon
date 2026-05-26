using System;
using System.Collections.Generic;

namespace KutuphaneOtomasyon.Models
{
    public class Kitap
    {
        public int Id { get; set; }

        public string KitapAdi { get; set; }

        public string Yazar { get; set; }

        public string Yayinevi { get; set; }

        public int BasimYili { get; set; }

        public string Isbn { get; set; }

        public string RafNo { get; set; }

        public int StokAdedi { get; set; }

        public virtual ICollection<Odunc> Oduncler { get; set; }

        public Kitap()
        {
            Oduncler = new List<Odunc>();
        }
    }
}