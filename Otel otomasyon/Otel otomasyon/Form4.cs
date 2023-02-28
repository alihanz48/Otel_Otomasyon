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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand("");
        private void Form4_Load(object sender, EventArgs e)
        {
            listView1.Size = new Size(this.Width-30,this.Height-16);
            listView1.Location = new Point(8,8);
            listView1.Items.Clear();

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from musteriler";
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
                listView1.Items.Add(item);
            }
            baglanti.Close();
        }
    }
}
