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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void Form7_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            this.WindowState = FormWindowState.Maximized;
            panel1.Location = new Point((((this.Width-panel1.Width))/2),30);

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from odalar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["oda_ad"]);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text==""||textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
            {
                MessageBox.Show("Boş alanlar mevcut olduğundan dolayı kayıt yapılamıyor");
            }
            else
            {
                ListViewItem item = new ListViewItem();
                item.Text = textBox1.Text;
                item.SubItems.Add(textBox2.Text);
                item.SubItems.Add(textBox3.Text);
                item.SubItems.Add(textBox4.Text);
                item.SubItems.Add(radioButton1.Checked == true ? "erkek" : "kadın");
                item.SubItems.Add(comboBox1.SelectedItem.ToString());
                item.SubItems.Add(dateTimePicker1.Value.ToString());
                item.SubItems.Add(dateTimePicker2.Value.ToString());
                listView2.Items.Add(item);

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                radioButton1.Checked = true;
                comboBox1.Text = null;
                dateTimePicker1.Value = System.DateTime.Now;
                dateTimePicker2.Value = System.DateTime.Now;
            }
                
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool drm = false;
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

                    if (veri[0]==null)
                    {
                        drm = false;
                    }
                    else
                    {
                        komut.CommandText = "INSERT INTO musteriler VALUES('" + veri[0] + "','" + veri[1] + "','" + veri[2] + "','" + veri[3] + "','" + veri[4] + "','" + veri[5] + "','" + veri[6] + "','" + veri[7] + "')";
                        komut.ExecuteNonQuery();
                    }
                    
                }
                baglanti.Close();
                drm = true;
            }
            catch (Exception)
            {
                drm = false;
            }

            if (listView2.Items.Count==0)
            {
                drm = false;
            }
            MessageBox.Show(drm==true? "Kayıt başarılı":"Kayıt başarısız tekrar deneyiniz");
            if (drm==true)
            {
                listView2.Items.Clear();
            }
        }
    }
}
