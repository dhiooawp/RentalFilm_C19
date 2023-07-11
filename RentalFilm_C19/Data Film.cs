using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalFilm_C19
{
    public partial class Film : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        private void refreshForm() 
        {
            tbKodeFilm.Text = "";
            tbKodeFilm.Enabled = false;

            tbJudulFilm.Text = "";
            tbJudulFilm.Enabled = false;

            tbRating.Text = "";
            tbRating.Enabled = false;

            tbDeskripsi.Text = "";
            tbDeskripsi.Enabled = false;

            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnDisplay.Enabled = false;
            btnSave.Enabled=false;
            btnUpdate.Enabled = false;
        }
        private void DataGridView()
        {
            koneksi.Open();
            string str = "select * from Film";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        public Film()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbKodeFilm.Enabled = true;
            tbJudulFilm.Enabled = true;
            tbRating.Enabled = true;
            tbDeskripsi.Enabled = true;
            btnClear.Enabled = true;
            btnDelete.Enabled = true;
            btnDisplay.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled=true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbKodeFilm.Text == "")
            {
                MessageBox.Show("Kode Film Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Film values(@kd_film, @deskripsi, @judul_film, @rating_film)", con);
                cmd.Parameters.AddWithValue("@kd_film", tbKodeFilm.Text);
                cmd.Parameters.AddWithValue("@deskripsi", tbDeskripsi.Text);
                cmd.Parameters.AddWithValue("@judul_film", tbJudulFilm.Text);
                cmd.Parameters.AddWithValue("@rating_film", int.Parse(tbRating.Text));
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Berhasil Di Simpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridView();
                refreshForm();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = new SqlCommand("update Film set kd_film = @kd_film, deskripsi = @deskripsi, judul_film = @judul_film, rating_film = @rating_film", koneksi);
            cmd.Parameters.AddWithValue("@kd_film", tbKodeFilm.Text);
            cmd.Parameters.AddWithValue("@deskripsi", tbDeskripsi.Text);
            cmd.Parameters.AddWithValue("@judul_film", tbJudulFilm.Text);
            cmd.Parameters.AddWithValue("@rating_film", int.Parse(tbRating.Text));
            cmd.ExecuteNonQuery();
            koneksi.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridView();
            refreshForm();


        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = new SqlCommand("delete Film where kd_film=@kd_film", koneksi);
            cmd.Parameters.AddWithValue("@kd_film", tbKodeFilm.Text);
            cmd.ExecuteNonQuery();
            koneksi.Close();

            MessageBox.Show("Data Berhasil Di Hapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridView();
            refreshForm();
        }
    }
}
