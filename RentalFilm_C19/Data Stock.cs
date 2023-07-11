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
    public partial class Stok : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Stok()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            cbPegawai();
            cbKodeFilm();
            refreshForm();
        }
        private void cbPegawai()
        {
            koneksi.Open();
            string str = "SELECT id_pegawai FROM Pegawai";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            while (dr.Read())
            {
                cbxPegawai.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
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
            string str = "select * from Stock";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void refreshForm()
        {
            tbStock.Enabled = false;
            cbxKodeFilm.Enabled = false;
            cbxPegawai.Enabled = false;
            dtTayang.Enabled = false;
            btnDelete.Enabled = false;
            btnDisplay.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbStock.Enabled = true;
            cbxKodeFilm.Enabled = true;
            cbxPegawai.Enabled = true;
            dtTayang.Enabled = true;
            btnDelete.Enabled = true;
            btnDisplay.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbStock.Text == "")
            {
                MessageBox.Show("Stock Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Stock values(@jumlah_stock, @id_pegawai, @jadwal_tayang, @kd_film)", con);
                cmd.Parameters.AddWithValue("@jumlah_stock", int.Parse(tbStock.Text));
                cmd.Parameters.AddWithValue("@id_pegawai", idPegawai.Text);
                cmd.Parameters.AddWithValue("@jadwal_tayang", dtTayang.Text);
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
            SqlCommand cmd = new SqlCommand("update Stock set jumlah_stock = @jumlah_stock, id_pegawai = @id_pegawai, jadwal_tayang = @jadwal_tayang, kd_film = @kd_film", con);
            cmd.Parameters.AddWithValue("@jumlah_stock", int.Parse(tbStock.Text));
            cmd.Parameters.AddWithValue("@id_pegawai", idPegawai.Text);
            cmd.Parameters.AddWithValue("@jadwal_tayang", dtTayang.Text);
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
            SqlCommand cmd = new SqlCommand("delete Stock where kd_film = kd_film", con);
            cmd.Parameters.AddWithValue("@kd_film", idFilm.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Hapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView();
        }

        private void cbxPegawai_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string strs = "select id_pegawai from dbo.Pegawai where nama_pegawai = @nama_pegawai";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            string selectedName = cbxPegawai.SelectedItem.ToString();
            cm.Parameters.AddWithValue("@nama_pegawai", selectedName);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                string nip = dr.GetString(0);
                idPegawai.Text = nip;
            }
            else
            {
                idPegawai.Text = "";
            }

            dr.Close();
            koneksi.Close();
        }

        private void cbxKodeFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string strs = "select kd_rental from dbo.RentalFilm where nama_rental = @nama_rental";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            string selectedName = cbxPegawai.SelectedItem.ToString();
            cm.Parameters.AddWithValue("@nama_rental", selectedName);
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
