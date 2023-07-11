using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalFilm_C19
{
    public partial class Rental : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Rental()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshForm();
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from RentalFilm";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void refreshForm()
        {
            tbAlamat.Enabled = false;
            tbHp.Enabled = false;
            tbKode.Enabled = false;
            tbNama.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbAlamat.Enabled = true;
            tbHp.Enabled = true;
            tbKode.Enabled = true;
            tbNama.Enabled = true;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbKode.Text == "")
            {
                MessageBox.Show("Kode Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into RentalFilm values(@kd_rental, @nama_rental, @alamat, @no_tlp)", con);
                cmd.Parameters.AddWithValue("@kd_rental", tbKode.Text);
                cmd.Parameters.AddWithValue("@nama_rental", tbNama.Text);
                cmd.Parameters.AddWithValue("@alamat", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@no_tlp", tbHp.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Berhasil Di Simpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshForm();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update RentalFilm set kd_rental = @kd_rental, nama_rental = @nama_rental, alamat = @alamat, no_tlp = @no_tlp", con);
            cmd.Parameters.AddWithValue("@kd_rental", tbKode.Text);
            cmd.Parameters.AddWithValue("@nama_rental", tbNama.Text);
            cmd.Parameters.AddWithValue("@alamat", tbAlamat.Text);
            cmd.Parameters.AddWithValue("@no_tlp", tbHp.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete RentalFilm where kd_rental = @kd_rental", con);
            cmd.Parameters.AddWithValue("@kd_rental", tbKode.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }
    }
}
