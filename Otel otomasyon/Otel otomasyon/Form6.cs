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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand();

        public void doldur()
        {
            listView1.Items.Clear();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from rezervasyonlar";
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
        private void Form6_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            panel2.Location = new Point(((this.Width-panel2.Width)/2),2*panel1.Height);
            panel2.Size = new Size(panel2.Width,this.Height-panel1.Height);
            listView1.Height = panel2.Height - listView1.Location.Y-100;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from odalar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["oda_ad"]);
            }
            baglanti.Close();
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!=""&&textBox1.Text!=""&&textBox2.Text!="")
            {
                ListViewItem item = new ListViewItem();
                item.Text = textBox1.Text;
                item.SubItems.Add(textBox2.Text);
                item.SubItems.Add(textBox3.Text);
                item.SubItems.Add(textBox4.Text);
                item.SubItems.Add(radioButton1.Checked==true? "erkek":"kadın");
                item.SubItems.Add(comboBox1.SelectedItem.ToString());
                item.SubItems.Add(dateTimePicker1.Value.ToString());
                item.SubItems.Add(dateTimePicker2.Value.ToString());
                listView2.Items.Add(item);

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                radioButton1.Checked = true;
                comboBox1.Text = "";
                dateTimePicker1.Value = System.DateTime.Now;
                dateTimePicker2.Value = System.DateTime.Now;
            }
            else
            {
                MessageBox.Show("Oda seçimi,İsim soyisim ve Tc/Id girmek zorunludur.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] veri = new string[8];
                baglanti.Open();
                komut.Connection = baglanti;
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    veri[0] = listView2.Items[i].Text;
                    for (int j = 1; j < 8; j++)
                    {
                        veri[j] = listView2.Items[i].SubItems[j].Text;
                    }
                    komut.CommandText = "INSERT INTO rezervasyonlar VALUES('" + veri[0] + "','" + veri[1] + "','" + veri[2] + "','" + veri[3] + "','" + veri[4] + "','" + veri[5] + "','" + veri[6] + "','" + veri[7] + "')";
                    komut.ExecuteNonQuery();
                }
                baglanti.Close();
                listView2.Items.Clear();
                doldur();
            }
            catch (Exception)
            {

            }          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listView2.Items.Remove(listView2.SelectedItems[0]);
            }
            catch (Exception){
               
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "delete from rezervasyonlar where id='" + listView1.SelectedItems[0].SubItems[1].Text + "' AND oda='" + listView1.SelectedItems[0].SubItems[5].Text + "' AND giris_tar='" + listView1.SelectedItems[0].SubItems[6].Text + "' AND cikis_tar='" + listView1.SelectedItems[0].SubItems[7].Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                doldur();
            }
            catch (Exception)
            {

            }    
        }
    }
}
