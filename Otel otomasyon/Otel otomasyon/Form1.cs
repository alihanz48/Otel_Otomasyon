using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Otel_otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(((this.Width/2)-(panel1.Width/2)),((this.Height/2)-(panel1.Height/2)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool dogrulama = false;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kayit WHERE kullanici_ad='"+textBox1.Text+"' AND sifre='"+textBox2.Text+"'";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Visible = false;
                dogrulama = true;
            }
            baglanti.Close();

            if (dogrulama==false)
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz yanlış.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form9 frm3 = new Form9();
            frm3.Show();
            this.Visible = false;
        }
    }
}
