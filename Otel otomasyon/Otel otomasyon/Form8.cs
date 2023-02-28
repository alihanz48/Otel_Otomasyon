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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void Form8_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM odalar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["oda_ad"]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM musteriler WHERE oda='"+comboBox1.SelectedItem+"'";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = oku["isim_soyisim"].ToString();
                item.SubItems.Add(oku["id"].ToString());
                item.SubItems.Add(oku["tel"].ToString());
                item.SubItems.Add(oku["mail"].ToString());
                item.SubItems.Add(oku["cinsiyet"].ToString());
                item.SubItems.Add(oku["oda"].ToString());
                item.SubItems.Add(oku["giris_tar"].ToString());
                item.SubItems.Add(oku["cikis_tar"].ToString());
                listView2.Items.Add(item);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool hata = false;
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    komut.CommandText = "DELETE FROM musteriler WHERE id='" + listView2.Items[i].SubItems[1].Text + "'";
                    komut.ExecuteNonQuery();
                }
                baglanti.Close();
            }
            catch (Exception)
            {
                hata = true;
            }

            if (listView2.Items.Count==0)
            {
                hata = true;
            }

            if (hata==true)
            {
                MessageBox.Show("Hata oluştu daha sonra tekrar deneyiniz");
            }
            else
            {
                MessageBox.Show("Oda boşaltma işlemi başarılı");
                comboBox1.Text = "";
                listView2.Items.Clear();
            }
        }
    }
}
