using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyon.Data;
using KutuphaneOtomasyon.Models;

namespace KutuphaneOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpAlisTarihi.Value = DateTime.Today;
            dtpTeslimTarihi.Value = DateTime.Today.AddDays(14);

            Listele();
        }
        private void Listele()
        {
            using (var db = new KutuphaneContext())
            {
                dgvKitaplar.DataSource = db.Kitaplar
                    .Select(k => new
                    {
                        k.Id,
                        k.KitapAdi,
                        k.Yazar,
                        k.Yayinevi,
                        k.BasimYili,
                        k.Isbn,
                        k.RafNo,
                        k.StokAdedi
                    })
                    .ToList();

                dgvUyeler.DataSource = db.Uyeler
                    .Select(u => new
                    {
                        u.Id,
                        u.AdSoyad,
                        u.Telefon,
                        u.Email,
                        u.KayitTarihi
                    })
                    .ToList();

                dgvOduncler.DataSource = db.Oduncler
                    .Select(o => new
                    {
                        o.Id,
                        Kitap = o.Kitap.KitapAdi,
                        Uye = o.Uye.AdSoyad,
                        o.AlisTarihi,
                        o.TeslimEdilecekTarih,
                        o.IadeTarihi,
                        Durum = o.IadeTarihi != null
                            ? "İade Edildi"
                            : o.TeslimEdilecekTarih < DateTime.Today
                                ? "Gecikti"
                                : "Emanette"
                    })
                    .ToList();

                cmbKitap.DataSource = db.Kitaplar
                    .Where(k => k.StokAdedi > 0)
                    .ToList();

                cmbKitap.DisplayMember = "KitapAdi";
                cmbKitap.ValueMember = "Id";

                cmbUye.DataSource = db.Uyeler
                    .ToList();

                cmbUye.DisplayMember = "AdSoyad";
                cmbUye.ValueMember = "Id";
            }
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKitapAdi.Text))
            {
                MessageBox.Show("Kitap adı boş olamaz.");
                return;
            }

            if (!int.TryParse(txtBasimYili.Text, out int basimYili))
            {
                MessageBox.Show("Basım yılı sayı olmalıdır.");
                return;
            }

            if (!int.TryParse(txtStokAdedi.Text, out int stokAdedi))
            {
                MessageBox.Show("Stok adedi sayı olmalıdır.");
                return;
            }

            using (var db = new KutuphaneContext())
            {
                Kitap yeniKitap = new Kitap
                {
                    KitapAdi = txtKitapAdi.Text,
                    Yazar = txtYazar.Text,
                    Yayinevi = txtYayinevi.Text,
                    BasimYili = basimYili,
                    Isbn = txtIsbn.Text,
                    RafNo = txtRafNo.Text,
                    StokAdedi = stokAdedi
                };

                db.Kitaplar.Add(yeniKitap);
                db.SaveChanges();
            }

            MessageBox.Show("Kitap başarıyla eklendi.");

            txtKitapAdi.Clear();
            txtYazar.Clear();
            txtYayinevi.Clear();
            txtBasimYili.Clear();
            txtIsbn.Clear();
            txtRafNo.Clear();
            txtStokAdedi.Clear();

            Listele();
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Ad soyad boş olamaz.");
                return;
            }

            using (var db = new KutuphaneContext())
            {
                Uye yeniUye = new Uye
                {
                    AdSoyad = txtAdSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Email = txtEmail.Text,
                    KayitTarihi = DateTime.Today
                };

                db.Uyeler.Add(yeniUye);
                db.SaveChanges();
            }

            MessageBox.Show("Üye başarıyla eklendi.");

            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();

            Listele();
        }

        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            if (cmbKitap.SelectedItem == null || cmbUye.SelectedItem == null)
            {
                MessageBox.Show("Kitap ve üye seçmelisin.");
                return;
            }

            Kitap secilenKitap = cmbKitap.SelectedItem as Kitap;
            Uye secilenUye = cmbUye.SelectedItem as Uye;

            if (secilenKitap == null || secilenUye == null)
            {
                MessageBox.Show("Seçilen kitap veya üye hatalı.");
                return;
            }

            if (dtpTeslimTarihi.Value.Date < dtpAlisTarihi.Value.Date)
            {
                MessageBox.Show("Teslim tarihi, alış tarihinden önce olamaz.");
                return;
            }

            using (var db = new KutuphaneContext())
            {
                Kitap kitap = db.Kitaplar.Find(secilenKitap.Id);

                if (kitap == null)
                {
                    MessageBox.Show("Kitap bulunamadı.");
                    return;
                }

                if (kitap.StokAdedi <= 0)
                {
                    MessageBox.Show("Bu kitap stokta yok.");
                    return;
                }

                Odunc yeniOdunc = new Odunc
                {
                    KitapId = secilenKitap.Id,
                    UyeId = secilenUye.Id,
                    AlisTarihi = dtpAlisTarihi.Value.Date,
                    TeslimEdilecekTarih = dtpTeslimTarihi.Value.Date,
                    IadeTarihi = null
                };

                kitap.StokAdedi--;

                db.Oduncler.Add(yeniOdunc);
                db.SaveChanges();
            }

            MessageBox.Show("Kitap başarıyla ödünç verildi.");

            Listele();
        }

        private void btnIadeAl_Click(object sender, EventArgs e)
        {
            if (dgvOduncler.CurrentRow == null)
            {
                MessageBox.Show("İade almak için ödünç kayıtlarından bir satır seç.");
                return;
            }

            int oduncId = Convert.ToInt32(dgvOduncler.CurrentRow.Cells["Id"].Value);

            using (var db = new KutuphaneContext())
            {
                Odunc odunc = db.Oduncler.Find(oduncId);

                if (odunc == null)
                {
                    MessageBox.Show("Ödünç kaydı bulunamadı.");
                    return;
                }

                if (odunc.IadeTarihi != null)
                {
                    MessageBox.Show("Bu kitap zaten iade edilmiş.");
                    return;
                }

                Kitap kitap = db.Kitaplar.Find(odunc.KitapId);

                if (kitap == null)
                {
                    MessageBox.Show("Kitap bulunamadı.");
                    return;
                }

                odunc.IadeTarihi = DateTime.Today;
                kitap.StokAdedi++;

                db.SaveChanges();
            }

            MessageBox.Show("Kitap başarıyla iade alındı.");

            Listele();
        }

        private void btnKitapAra_Click(object sender, EventArgs e)
        {
            using (var db = new KutuphaneContext())
            {
                string aranan = txtKitapAra.Text.ToLower();

                dgvKitaplar.DataSource = db.Kitaplar
                    .Where(k => k.KitapAdi.ToLower().Contains(aranan) ||
                                k.Yazar.ToLower().Contains(aranan) ||
                                k.Isbn.ToLower().Contains(aranan))
                    .ToList();
            }
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            if (dgvKitaplar.CurrentRow == null)
            {
                MessageBox.Show("Silmek için bir kitap seçmelisin.");
                return;
            }

            int kitapId = Convert.ToInt32(dgvKitaplar.CurrentRow.Cells["Id"].Value);

            DialogResult cevap = MessageBox.Show(
                "Bu kitabı silersen bu kitaba ait ödünç kayıtları da silinir. Emin misin?",
                "Kitap Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (cevap == DialogResult.No)
            {
                return;
            }

            using (var db = new KutuphaneContext())
            {
                Kitap kitap = db.Kitaplar.Find(kitapId);

                if (kitap == null)
                {
                    MessageBox.Show("Kitap bulunamadı.");
                    return;
                }

                var oduncKayitlari = db.Oduncler
                    .Where(o => o.KitapId == kitapId)
                    .ToList();

                foreach (var odunc in oduncKayitlari)
                {
                    db.Oduncler.Remove(odunc);
                }

                db.Kitaplar.Remove(kitap);

                db.SaveChanges();
            }

            MessageBox.Show("Kitap ve kitaba ait ödünç kayıtları başarıyla silindi.");

            Listele();
        }

        private void btnUyeSil_Click(object sender, EventArgs e)
        {
            if (dgvUyeler.CurrentRow == null)
            {
                MessageBox.Show("Silmek için bir üye seçmelisin.");
                return;
            }

            int uyeId = Convert.ToInt32(dgvUyeler.CurrentRow.Cells["Id"].Value);

            DialogResult cevap = MessageBox.Show(
                "Bu üyeyi silersen bu üyeye ait ödünç kayıtları da silinir. Emin misin?",
                "Üye Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (cevap == DialogResult.No)
            {
                return;
            }

            using (var db = new KutuphaneContext())
            {
                Uye uye = db.Uyeler.Find(uyeId);

                if (uye == null)
                {
                    MessageBox.Show("Üye bulunamadı.");
                    return;
                }

                var oduncKayitlari = db.Oduncler
                    .Where(o => o.UyeId == uyeId)
                    .ToList();

                foreach (var odunc in oduncKayitlari)
                {
                    db.Oduncler.Remove(odunc);
                }

                db.Uyeler.Remove(uye);

                db.SaveChanges();
            }

            MessageBox.Show("Üye ve üyeye ait ödünç kayıtları başarıyla silindi.");

            Listele();
        }
    }
}

