using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sinema_otomasyon
{
    public partial class Form2 : Form
    {
        veritabani yeni = new veritabani();
        
        
        public Form2()
        {
            InitializeComponent();
            this.Text = "Ana Sayfa";
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = yeni.film_seans.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 frm6 = new Form6();
            frm6.ShowDialog();
        }

      
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
                
                //pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
        }

            private void button2_Click(object sender, EventArgs e)
        {
            
            Form8 p = new Form8();
            p.textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            p.textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            p.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            p.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            p.ShowDialog();
            
        }
     
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = yeni.film_seans.Where(x => x.film_adi.Contains(textBox1.Text) || x.salon_adi.Contains(textBox1.Text) || x.seans_saat.Contains(textBox1.Text)).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
