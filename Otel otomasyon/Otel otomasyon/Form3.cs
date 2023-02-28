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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand("");

        public void kayit_al()
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM odalar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listBox1.Items.Add(oku["oda_ad"]);
                comboBox1.Items.Add(oku["oda_ad"]);
            }
            baglanti.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            kayit_al();
            panel3.Location = new Point(panel1.Width+1,panel2.Height+1);
            panel3.Size = new Size((this.Width - panel1.Width),(this.Height-panel2.Height-50));
            listBox1.Height = this.Height - listBox1.Location.Y - 80;
            yataklar();
        }

        public void yataklar()
        {
            panel3.Controls.Clear();
            int x = 20;
            int y = 10;
            Panel pnlyatak;

            foreach (string item in listBox1.Items)
            {
                if (panel1.Width + x + 120 > (panel3.Location.X + panel3.Width))
                {
                    x = 20;
                    y += 120;
                }

                int drm = 0;

                pnlyatak = new Panel();
                pnlyatak.Size = new Size(100, 110);
                pnlyatak.Location = new Point(x, y);
                pnlyatak.BackgroundImageLayout = ImageLayout.Stretch;
                pnlyatak.Name = item;

                Label odaism = new Label();
                odaism.Text = item.ToString();
                odaism.Size = new Size(pnlyatak.Width, 50);
                odaism.Location = new Point(x,((y + pnlyatak.Height) - odaism.Height));
                odaism.TextAlign = ContentAlignment.MiddleCenter;

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "select * from musteriler where oda='" + item + "'";
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    drm = 1;
                }

                if (drm == 1)
                {
                    pnlyatak.BackgroundImage = Resource1.kirmizi_yatak;
                }
                else
                {
                    pnlyatak.BackgroundImage = Resource1.yesil_yatak;
                }

                panel3.Controls.Add(pnlyatak);
                pnlyatak.BringToFront();
                panel3.Controls.Add(odaism);
                odaism.BringToFront();
                panel3.SendToBack();
                x += 120;
                baglanti.Close();
                pnlyatak.Click += Pnlyatak_Click;
            }
            
        }

        private void Pnlyatak_Click(object sender, EventArgs e)
        {
            Panel panelclick =(Panel)sender;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM musteriler WHERE oda='"+panelclick.Name+"'";
            OleDbDataReader oku = komut.ExecuteReader();
            string kisiler="";
            while (oku.Read())
            {
                kisiler += "\n Ad Soyad : " + oku["isim_soyisim"] + "\n ID : " + oku["id"] + "\n Telefon : " + oku["tel"] + "\n Mail : " + oku["mail"] + "\n Cinsiyet : " + oku["cinsiyet"] + "\n Oda : " + oku["oda"] + "\n Giriş Tarihi : " + oku["giris_tar"] + "\n Çıkış Tarihi : " + oku["cikis_tar"]+"\n-----------------------------------------";
            }
            baglanti.Close();
            if (kisiler!="")
            {
                MessageBox.Show(kisiler);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                if (listBox1.Items.Contains(textBox1.Text))
                {
                    MessageBox.Show("Bu isimde bir oda mevcut,farklı isim ile deneyiniz.");
                }
                else
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into odalar Values('" + textBox1.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    textBox1.Text = "";
                    kayit_al();
                    yataklar();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "DELETE FROM odalar WHERE oda_ad='" + comboBox1.Text.ToString() + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                kayit_al();
                yataklar();
            }  
        }  
    }
}
