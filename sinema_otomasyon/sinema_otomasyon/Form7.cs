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
    public partial class Form7 : Form
    {
        veritabani yeni = new veritabani();
        SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        

        public Form7()
        {
            InitializeComponent();
        }
        bool durum;
        void tekrar()
        {
            foreach (object item in checkedListBox1.CheckedItems)
            {
                string checkedItem = item.ToString();
                label8.Text = label8.Text + checkedItem + ",";
            }

            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM filmler WHERE film_adi=@film_adi and film_turu=@film_turu and yonetmen_adi=@yonetmen_adi and film_oyuncu=@film_oyuncu and film_tarih=@film_tarih and film_resim=@film_resim and yapimci_adi=@yapimci_adi", baglan);
            cmd.Parameters.AddWithValue("@film_adi", textBox1.Text);
            cmd.Parameters.AddWithValue("@film_turu", comboBox1.Text);
            cmd.Parameters.AddWithValue("@yonetmen_adi", comboBox2.Text);
            cmd.Parameters.AddWithValue("@film_oyuncu", label8.Text.ToString());
            cmd.Parameters.AddWithValue("@yapimci_adi", comboBox5.Text);
            cmd.Parameters.AddWithValue("@film_tarih", dateTimePicker1.Value.ToString());
            cmd.Parameters.AddWithValue("@film_resim", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglan.Close();
        }
        public void Form7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlDataReader dr;
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT * FROM film_kategori";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["tur_adi"]);
            }
            baglan.Close();

            comboBox2.Items.Clear();
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT * FROM yonetmen";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["yonetmen_adi"]);

            }
            baglan.Close();

            comboBox5.Items.Clear();
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT * FROM yapimci";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox5.Items.Add(dr["yapimci_adi"]);

            }
            baglan.Close();


            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT * FROM oyuncu";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                checkedListBox1.Items.Add(dr["film_oyuncu"]);
            }
            baglan.Close();

        }

        public void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            textBox2.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tekrar();
            if (durum == true)
            {
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    string checkedItem = item.ToString();
                    label8.Text = label8.Text + checkedItem + ",";
                }
                string sorgu = "UPDATE filmler SET film_adi=@film_adi, film_turu=@film_turu, yonetmen_adi=@yonetmen_adi, film_oyuncu=@film_oyuncu, film_tarih=@film_tarih, film_resim=@film_resim,yapimci_adi=@yapimci_adi  WHERE film_id=@film_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@film_id", Convert.ToInt32(textBox3.Text));
                cmd.Parameters.AddWithValue("@film_adi", textBox1.Text);
                cmd.Parameters.AddWithValue("@film_turu", comboBox1.Text);
                cmd.Parameters.AddWithValue("@yonetmen_adi", comboBox2.Text);
                cmd.Parameters.AddWithValue("@film_oyuncu", label8.Text.ToString());
                cmd.Parameters.AddWithValue("@yapimci_adi", comboBox5.Text);
                cmd.Parameters.AddWithValue("@film_tarih", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@film_resim", textBox2.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Başarıyla güncellendi", "Bilgi");
                this.Close();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
    }
}
