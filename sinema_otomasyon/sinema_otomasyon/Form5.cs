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
    public partial class Form5 : Form
    {
        SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        

        public Form5()
        {
            InitializeComponent();
            this.Text = "Ayarlar";
        }
        


        void doldur()
        {
            baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM admin", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            doldur();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

       //Güncelleme 

        private void button3_Click(object sender, EventArgs e)
        {

            string sorgu = "UPDATE admin SET admin_kadi = @admin_kadi, admin_sifre=@admin_sifre";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@admin_kadi", textBox1.Text);
            cmd.Parameters.AddWithValue("@admin_sifre", textBox2.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldur();
            MessageBox.Show("Başarıyla güncellendi", "Bilgi");


        }

        private void anasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
