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
    
    public partial class Form8 : Form
    {
        
        

        public Form8()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        int sayac = 0;
        private void Form8_Load(object sender, EventArgs e)
        {
            //foreach (Control ct in this.Controls)
            //{
            //    if (ct is Button)
            //    {
            //        ct.BackColor = Color.White;
            //    }
            //}
            BosKoltuklar();
            DoluKoltuklar();
            //YenidenRenklendir();
            //Koltukİptal();
            BiletKes();

        }

        //private void YenidenRenklendir()
        //{
        //    foreach (Control item in panel1.Controls)
        //    {
        //        if (item is Button)
        //        {
        //            item.BackColor = Color.Blue;
        //        }
        //    }
        //}
        void DoluKoltuklar()
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            
            baglan.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM bilet WHERE film_adi='"+textBox4.Text+ "' and  seans_saat='" + textBox2.Text + "' and salon_adi='" + textBox3.Text + "' and koltuk_no='" + textBox5.Text + "' and koltuk_durum='koltuk_durum' ", baglan);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (dr["koltuk_durum"].ToString()=="dolu")
                        {
                            BackColor = Color.Red;
                        }else
                        {
                            BackColor = Color.Green;
                        }
                        
                    }
                }
            }
            baglan.Close();
        }
        void Koltukİptal()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor ==Color.Red)
                    {
                        comboBox1.Items.Add(item.Text);
                    }
                }
            }
        }

        private void BosKoltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(60, 60),
                        BackColor = Color.Green,
                        Location = new Point(j * 60 + 20, i * 60 + 30),
                        Name = sayac.ToString(),
                        Text = sayac.ToString()
                    };
                    if (j == 5)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;

                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.BackColor == Color.Green)
            {
                textBox5.Text = b.Text;
            }
        }
        private void BiletKes()
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            string sorgu = "INSERT INTO bilet(film_adi,bilet_isim,seans_saat,salon_adi,koltuk_no,koltuk_durum) VALUES(@film_adi,@bilet_isim,@seans_saat,@salon_adi,@koltuk_no,@koltuk_durum)";
            SqlCommand cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@film_adi", textBox4.Text);
            cmd.Parameters.AddWithValue("@bilet_isim", textBox1.Text);
            cmd.Parameters.AddWithValue("@seans_saat", textBox2.Text);
            cmd.Parameters.AddWithValue("@salon_adi", textBox3.Text);
           // cmd.Parameters.AddWithValue("@seans_tarih", dateTimePicker1.Value.ToString());
           // cmd.Parameters.AddWithValue("@musteri_tipi", textBox8.Text);
            cmd.Parameters.AddWithValue("@koltuk_no", textBox5.Text);
            cmd.Parameters.AddWithValue("@koltuk_durum", "dolu");
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BiletKes();
                MessageBox.Show("Bilet Satıldı!", "Başarılı ✅");
            }
            catch (Exception)
            {

                MessageBox.Show("Koltuk Seçimi Yapmadınız!", "Uyarı ❌");
            }
        }
    }
}
