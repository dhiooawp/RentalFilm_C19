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
    public partial class Barang : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Barang()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshForm();
            cbKodeRental();
            cbKodeDistributor();
        }
        private void cbKodeDistributor()
        {
            koneksi.Open();
            string str = "SELECT nama FROM Distributor";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            while (dr.Read())
            {
                cbxKodeDistributor.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
        }
        private void cbKodeRental()
        {
            koneksi.Open();
            string str = "SELECT nama_rental FROM RentalFilm";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            while (dr.Read())
            {
                cbxKodeRental.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from InformasiBarang";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void refreshForm()
        {
            tbNama.Text = "";
            cbxKodeDistributor.Enabled = false;
            cbxKodeRental.Enabled = false;
            dtKirim.Enabled = false;
            dtTerima.Enabled = false;
            tbNama.Enabled = false;
            dtKirim.Enabled = false;
            dtTerima.Enabled = false;
            btnDelete.Enabled = false;
            btnDisplay.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbxKodeDistributor.Enabled = true;
            cbxKodeRental.Enabled = true;
            dtKirim.Enabled = true;
            dtTerima.Enabled = true;
            tbNama.Enabled = true;
            dtKirim.Enabled = true;
            dtTerima.Enabled = true;
            btnDelete.Enabled = true;
            btnDisplay.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
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
                SqlCommand cmd = new SqlCommand("insert into InformasiBarang values(@nama, @kd_distributor, @tgl_pengirim, @tgl_penerima, @kd_rental)", con);
                cmd.Parameters.AddWithValue("@nama", tbNama.Text);
                cmd.Parameters.AddWithValue("@kd_distributor", idDistributor.Text);
                cmd.Parameters.AddWithValue("@tgl_pengirim", dtKirim.Text);
                cmd.Parameters.AddWithValue("@tgl_penerima", dtTerima.Text);
                cmd.Parameters.AddWithValue("@kd_rental", idRental.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Berhasil Di Simpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshForm();

            }
        }

        private void cbxKodeDistributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string strs = "select kd_distributor from dbo.Distributor where nama = @nama";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            string selectedName = cbxKodeDistributor.SelectedItem.ToString();
            cm.Parameters.AddWithValue("@nama", selectedName);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                string nip = dr.GetString(0);
                idDistributor.Text = nip;
            }
            else
            {
                idDistributor.Text = "";
            }

            dr.Close();
            koneksi.Close();
        }

        private void cbxKodeRental_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string strs = "select kd_rental from dbo.RentalFilm where nama_rental = @nama_rental";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            string selectedName = cbxKodeRental.SelectedItem.ToString();
            cm.Parameters.AddWithValue("@nama_rental", selectedName);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                string nip = dr.GetString(0);
                idRental.Text = nip;
            }
            else
            {
                idRental.Text = "";
            }

            dr.Close();
            koneksi.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update InformasiBarang set nama = @nama, kd_distributor = @kd_distributor, tgl_pengirim = @tgl_pengirim, tgl_penerima = @tgl_penerima, kd_rental = @kd_rental", con);
            cmd.Parameters.AddWithValue("@nama", tbNama.Text);
            cmd.Parameters.AddWithValue("@kd_distributor", idDistributor.Text);
            cmd.Parameters.AddWithValue("@tgl_pengirim", dtKirim.Text);
            cmd.Parameters.AddWithValue("@tgl_penerima", dtTerima.Text);
            cmd.Parameters.AddWithValue("@kd_rental", idRental.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi = new SqlConnection(stringConnection);
            koneksi.Open();
            SqlCommand cmd = new SqlCommand("delete InformasiBarang where nama = @nama", koneksi);
            cmd.Parameters.AddWithValue("@nama", tbNama.Text);
            cmd.ExecuteNonQuery();
            koneksi.Close();

            MessageBox.Show("Data Berhasil Di Hapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView();
        }
    }
}
