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

namespace Otel_otomasyon
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(((this.Width/2)-(panel1.Width/2)),((this.Height/2)-(panel1.Height/2)));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Visible = false;
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text==maskedTextBox2.Text)
            {
                bool kkad = false;
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM kayit WHERE kullanici_ad='" + textBox1.Text + "'";
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kkad = true;
                }
                baglanti.Close();

                if (kkad == false)
                {
                    bool hata = false;
                    try
                    {
                        baglanti.Open();
                        komut.Connection = baglanti;
                        komut.CommandText = "INSERT INTO kayit VALUES('" + textBox1.Text + "','" + maskedTextBox1.Text + "')";
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    catch (Exception)
                    {
                        hata = true;
                    }

                    if (hata==false)
                    {
                        MessageBox.Show("Kayıt başarılı");
                        textBox1.Text = "";
                        maskedTextBox1.Text = "";
                        maskedTextBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarısız,daha sonra tekrar deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcı adı kullanılıyor,başka bir kullanıcı adı deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor");
            }
        }
    }
}
