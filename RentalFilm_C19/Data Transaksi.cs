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
    public partial class Transaksi : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Transaksi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            cbNamaPelanggan();
            cbNamaPegawai();
            refreshForm();
        }
        private void cbNamaPegawai()
        {
            koneksi.Open();
            string str = "SELECT id_pegawai FROM Pegawai";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            while (dr.Read())
            {
                cbPegawai.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
        }
        private void cbNamaPelanggan()
        {
            koneksi.Open();
            string str = "SELECT id_pelanggan FROM Pelanggan";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            while (dr.Read())
            {
                cbNama.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from Transaksi";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void refreshForm()
        {
            tbBayar.Enabled = false;
            cbPegawai.Enabled = false;
            dtSewa.Enabled = false;
            cbMetode.Enabled = false;
            cbNama.Enabled = false;
            btnDelete.Enabled = false;
            btnDisplay.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbBayar.Enabled = true;
            cbPegawai.Enabled = true;
            dtSewa.Enabled = true;
            cbMetode.Enabled = true;
            cbNama.Enabled = true;
            btnDelete.Enabled = true;
            btnDisplay.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbNama.Text == "")
            {
                MessageBox.Show("Nama Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Transaksi values(@jumlah_stock, @metode_pembayaran, @tgl_sewa, @id_pelanggan, @id_pegawai)", con);
                cmd.Parameters.AddWithValue("@jumlah_stock", int.Parse(tbBayar.Text));
                cmd.Parameters.AddWithValue("@metode_pembayaran", cbMetode.Text);
                cmd.Parameters.AddWithValue("@tgl_sewa", dtSewa.Text);
                cmd.Parameters.AddWithValue("@id_pelanggan", idPelanggan.Text);
                cmd.Parameters.AddWithValue("@id_pegawai", idPegawai.Text);
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
            SqlCommand cmd = new SqlCommand("update Transaksi set jumlah_stock = @jumlah_stock, metode_pembayaran = @metode_pembayaran, tgl_sewa = @tgl_sewa, id_pelanggan = @id_pelanggan, id_pegawai = @id_pegawai", con);
            cmd.Parameters.AddWithValue("@jumlah_stock", int.Parse(tbBayar.Text));
            cmd.Parameters.AddWithValue("@metode_pembayaran", cbMetode.Text);
            cmd.Parameters.AddWithValue("@tgl_sewa", dtSewa.Text);
            cmd.Parameters.AddWithValue("@id_pelanggan", idPelanggan.Text);
            cmd.Parameters.AddWithValue("@id_pegawai", idPegawai.Text);
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
            SqlCommand cmd = new SqlCommand("delete Transaksi where tgl_sewa = @tgl_sewa", con);
            cmd.Parameters.AddWithValue("@tgl_sewa", dtSewa.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }
    }
}
