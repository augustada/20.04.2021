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
    public partial class Form4 : Form
    {
        SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        
        public Form4()
        {
            InitializeComponent();
            this.Text = "İşlemler Sayfası";
        }
        bool durum;
        // Seçime göre kategori verilerini çekme
        void tekrar()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM film_kategori WHERE tur_adi=@tur_adi", baglan);
            cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
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
        // Seçime göre oyuncu verilerini çekme
        void tekrariki()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM oyuncu WHERE film_oyuncu=@film_oyuncu", baglan);
            cmd.Parameters.AddWithValue("@film_oyuncu", textBox2.Text);
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
        // Seçime göre salon verilerini çekme
        void tekrarsalon()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM salon WHERE salon_adi=@salon_adi", baglan);
            cmd.Parameters.AddWithValue("@salon_adi", textBox12.Text);
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
        // Seçime göre yönetmen verilerini çekme
        void tekrarson()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM yonetmen WHERE yonetmen_adi=@yonetmen_adi", baglan);
            cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
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
        // Film Kategori Listeleme
        void doldur()
        {
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM film_kategori", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        // Film Oyuncu Listeleme
        void dolduriki()
        {
            
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM oyuncu", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglan.Close();
        }

        // Film Salon Listeleme
        void doldursalon()
        {

            baglan.Open();
            da = new SqlDataAdapter("SELECT salon_id,salon_adi FROM salon", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView8.DataSource = tablo;
            baglan.Close();
        }
        // Film Yapımcı Listeleme
        void dolduruc()
        {
            
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM yapimci", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            baglan.Close();
        }
        // Seçime göre yapımcı verilerini çekme
        void tekraruc()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM yapimci WHERE yapimci_adi=@yapimci_adi", baglan);
            cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
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

        // Seçime göre seans verilerini çekme
        void tekrarseans()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM seans WHERE seans_saat=@seans_saat", baglan);
            cmd.Parameters.AddWithValue("@seans_saat", textBox10.Text);
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
        // Film Seans Listeleme
        void doldurseans()
        {
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM seans", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView7.DataSource = tablo;
            baglan.Close();
        }
        // Film Seans Listeleme 2
        void doldurseans2()
        {
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM seans", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView6.DataSource = tablo;
            baglan.Close();
        }
        // Filmleri Listeleme
        void doldurfilm()
        {
            comboBox1.Items.Clear();
            SqlDataReader dr;
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT DISTINCT film_adi FROM filmler";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["film_adi"]);
            }
            baglan.Close();
        }

        // Yönetmeni Listeleme
        void doldurson()
        {
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM yonetmen", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglan.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            doldur();
            dolduriki();
            dolduruc();
            doldurseans();
            doldurson();
            doldurfilm();
            doldurdata();
            doldurseans2();
            doldursalon();

        }

        //FİLM KATEGORİ
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tekrar();
            if (durum == true)
            {
                string sorgu = "INSERT INTO film_kategori(tur_adi) VALUES(@tur_adi)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldur();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tekrar();
            if (durum == true)
            {
                string sorgu = "UPDATE film_kategori SET tur_adi=@tur_adi WHERE tur_id=@tur_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@tur_id", Convert.ToInt32(textBox4.Text));
                cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldur();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM film_kategori WHERE tur_adi=@tur_adi";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldur();

        }



        // YAPIMCI İŞLEMLERİ
        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            tekraruc();
            if (durum == true)
            {
                string sorgu = "INSERT INTO yapimci(yapimci_adi) VALUES(@yapimci_adi)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduruc();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            tekraruc();
            if (durum == true)
            {
                string sorgu = "UPDATE yapimci SET yapimci_adi=@yapimci_adi WHERE yapimci_id=@yapimci_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@yapimci_id", Convert.ToInt32(textBox7.Text));
                cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduruc();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM yapimci WHERE yapimci_adi=@yapimci_adi";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            dolduruc();
        }

        //OYUNCU İŞLEMLERİ
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tekrariki();
            if (durum == true)
            {
                string sorgu = "INSERT INTO oyuncu(film_oyuncu) VALUES(@film_oyuncu)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@film_oyuncu", textBox2.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduriki();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tekrariki();
            if (durum == true)
            {
                string sorgu = "UPDATE oyuncu SET film_oyuncu=@film_oyuncu WHERE oyuncu_id=@oyuncu_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@oyuncu_id", Convert.ToInt32(textBox5.Text));
                cmd.Parameters.AddWithValue("@film_oyuncu", textBox2.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduriki();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM oyuncu WHERE film_oyuncu=@film_oyuncu";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@oyuncu_adi", textBox2.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            dolduriki();
        }

        //YÖNETMEN İŞLEMLERİ
        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tekrarson();
            if (durum == true)
            {
                string sorgu = "INSERT INTO yonetmen(yonetmen_adi) VALUES(@yonetmen_adi)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldurson();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            tekrarson();
            if (durum == true)
            {
                string sorgu = "UPDATE yonetmen SET yonetmen_adi=@yonetmen_adi WHERE yonetmen_id=@yonetmen_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@yonetmen_id", Convert.ToInt32(textBox6.Text));
                cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldurson();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM yonetmen WHERE yonetmen_adi=@yonetmen_adi";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldurson();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
        // Oyuncu İşlemleri Paneli
        private void label7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }
        // Yönetmen İşlemleri Paneli
        private void label1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }
        // Yapımcı İşlemleri Paneli
        private void label6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }
        // Kategori İşlemleri Paneli
        private void label3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            tekraruc();
            if (durum == true)
            {
                string sorgu = "INSERT INTO yapimci(yapimci_adi) VALUES(@yapimci_adi)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduruc();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            tekraruc();
            if (durum == true)
            {
                string sorgu = "UPDATE yapimci SET yapimci_adi=@yapimci_adi WHERE yapimci_id=@yapimci_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@yapimci_id", Convert.ToInt32(textBox7.Text));
                cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduruc();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM yapimci WHERE yapimci_adi=@yapimci_adi";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@yapimci_adi", textBox8.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            dolduruc();
        }

        private void dataGridView4_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
        }
        // Seans İşlemleri Paneli
        private void label9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        // Salon isimlerini doldurma
        void doldurdata()
        {
            baglan.Open();
            da = new SqlDataAdapter("SELECT salon_adi FROM salon", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView5.DataSource = tablo;
            baglan.Close();
        }
        

       

        private void button14_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.SelectedRows.Count; i++)
            {
                for (int j = 0; j < dataGridView6.SelectedRows.Count; j++)
                {



                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into film_seans(film_adi,seans_tarih,salon_adi,seans_saat,film_resim)values" + "(@film_adi,@seans_tarih,@salon_adi,@seans_saat,@film_resim)", baglan);
                    cmd.Parameters.AddWithValue("@film_adi", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@seans_tarih", dateTimePicker1.Value.ToString());
                    cmd.Parameters.AddWithValue("@salon_adi", dataGridView5.SelectedRows[i].Cells["salon_adi"].Value.ToString());
                    cmd.Parameters.AddWithValue("@seans_saat", dataGridView6.SelectedRows[j].Cells["seans_saat"].Value.ToString());
                    cmd.Parameters.AddWithValue("@film_resim", textBox13.Text);



                    cmd.ExecuteNonQuery();
                    baglan.Close();
                    doldurseans2();
                    

                }
            }


            MessageBox.Show("Başarıyla Eklendi", "Bilgi");
        }
        // Filme Seans Ekleme Paneli
        private void label12_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;

        }

        private void dataGridView7_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView7.CurrentRow.Cells[0].Value.ToString();
            textBox10.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tekrarseans();
            if (durum == true)
            {
                string sorgu = "INSERT INTO seans(seans_saat) VALUES(@seans_saat)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@seans_saat", textBox10.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldurseans();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            tekrarseans();
            if (durum == true)
            {
                string sorgu = "UPDATE seans SET seans_saat=@seans_saat WHERE seans_id=@seans_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@seans_id", Convert.ToInt32(textBox9.Text));
                cmd.Parameters.AddWithValue("@seans_saat", textBox10.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldurseans();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM seans WHERE seans_saat=@seans_saat";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@seans_saat", textBox10.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldurseans();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;

        }

        private void dataGridView8_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox11.Text = dataGridView8.CurrentRow.Cells[0].Value.ToString();
            textBox12.Text = dataGridView8.CurrentRow.Cells[1].Value.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tekrarsalon();
            if (durum == true)
            {
                string sorgu = "INSERT INTO salon(salon_adi) VALUES(@salon_adi)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@salon_adi", textBox12.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldursalon();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tekrarsalon();
            if (durum == true)
            {
                string sorgu = "UPDATE salon SET salon_adi=@salon_adi WHERE salon_id=@salon_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@salon_id", Convert.ToInt32(textBox11.Text));
                cmd.Parameters.AddWithValue("@salon_adi", textBox12.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldursalon();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM salon WHERE salon_adi=@salon_adi";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@salon_adi", textBox12.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldursalon();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM filmler where film_adi='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox13.Text = dr["film_resim"].ToString();

            }
            baglan.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM filmler where film_adi='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox13.Text = dr["film_resim"].ToString();

            }
            baglan.Close();
        }
    }
 }
    

