using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_otomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel7.Location = new Point(((this.Width/2)-(panel7.Width/2)),((this.Height/2)-(panel7.Height/2)));
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Transparent;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.White;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Transparent;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.White;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Transparent;
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.White;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Transparent;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }
    }
}
