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
    public partial class Pelanggan : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Pelanggan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            cbKodeFilm();
            refreshForm();
        }
        private void cbKodeFilm()
        {
            koneksi.Open();
            string str = "SELECT kd_film FROM Film";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            while (dr.Read())
            {
                cbxKodeFilm.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from Pelanggan";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void refreshForm()
        {
            tbAlamat.Text = "";
            tbHp.Text = "";
            tbID.Text = "";
            tbNama.Text = "";
            tbAlamat.Enabled = false;
            tbHp.Enabled = false;
            tbID.Enabled = false;
            tbNama.Enabled = false;
            cbxKodeFilm.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbAlamat.Enabled = true;
            tbHp.Enabled = true;
            tbID.Enabled = true;
            tbNama.Enabled = true;
            cbxKodeFilm.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbNama.Text == "")
            {
                MessageBox.Show("Nama Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Pelanggan values(@id_pelanggan, @nama_pelanggan, @alamat, @no_tlp, @kd_film)", con);
                cmd.Parameters.AddWithValue("@id_pelanggan", tbID.Text);
                cmd.Parameters.AddWithValue("@nama_pelanggan", tbNama.Text);
                cmd.Parameters.AddWithValue("@alamat", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@no_tlp", tbHp.Text);
                cmd.Parameters.AddWithValue("@kd_film", idFilm.Text);
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
            SqlCommand cmd = new SqlCommand("update Pelanggan set id_pelanggan = @id_pelanggan, nama_pelanggan = @nama_pelanggan, alamat = @alamat, no_tlp = @no_tlp, kd_film = @kd_film", con);
            cmd.Parameters.AddWithValue("@id_pelanggan", tbNama.Text);
            cmd.Parameters.AddWithValue("@nama_pelanggan", tbNama.Text);
            cmd.Parameters.AddWithValue("@alamat", tbAlamat.Text);
            cmd.Parameters.AddWithValue("@no_tlp", tbHp.Text);
            cmd.Parameters.AddWithValue("@kd_film", idFilm.Text);
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
            SqlCommand cmd = new SqlCommand("delete Pelanggan where id_pelanggan = @id_pelanggan", con);
            cmd.Parameters.AddWithValue("@id_pelanggan", tbNama.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void cbxKodeFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string strs = "select kd_film from dbo.Film where judul_film = @judul_film";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            string selectedName = cbxKodeFilm.SelectedItem.ToString();
            cm.Parameters.AddWithValue("@judul_film", selectedName);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                string nip = dr.GetString(0);
                idFilm.Text = nip;
            }
            else
            {
                idFilm.Text = "";
            }

            dr.Close();
            koneksi.Close();
        }
    }
}
