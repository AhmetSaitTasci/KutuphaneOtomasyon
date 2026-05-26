using KutuphaneOtomasyon.Models;
using KutuphaneOtomasyon.Models;
using System.Data.Entity;

namespace KutuphaneOtomasyon.Data
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext() : base("KutuphaneBaglanti")
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<Uye> Uyeler { get; set; }

        public DbSet<Odunc> Oduncler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Odunc>()
                .HasRequired(o => o.Kitap)
                .WithMany(k => k.Oduncler)
                .HasForeignKey(o => o.KitapId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Odunc>()
                .HasRequired(o => o.Uye)
                .WithMany(u => u.Oduncler)
                .HasForeignKey(o => o.UyeId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}