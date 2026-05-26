using KutuphaneOtomasyon;
using KutuphaneOtomasyon.Data;
using KutuphaneOtomasyon.Data;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database.SetInitializer(new KutuphaneInitializer());

            using (var db = new KutuphaneContext())
            {
                db.Database.Initialize(false);
            }

            Application.Run(new Form1());
        }
    }
}