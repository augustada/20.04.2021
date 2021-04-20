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
    public partial class Form6 : Form
    {
        SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        public Form6()
        {
            InitializeComponent();
        }
        void doldur()
        {
            baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM filmler ORDER BY film_adi ASC", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                string sorgu = "DELETE FROM filmler WHERE film_adi=@film_adi";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@film_adi", dataGridView1.SelectedRows[i].Cells["film_adi"].Value.ToString());
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldur();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 p = new Form7();
            p.textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            p.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            p.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            p.comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            p.checkedListBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            p.comboBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            p.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            p.textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            p.pictureBox2.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            p.ShowDialog();
            doldur();
        }
    }
}
