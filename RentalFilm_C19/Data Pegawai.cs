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
    public partial class Pegawai : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Pegawai()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            cbKodeRental();
            refreshForm();
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from Pegawai";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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
                cbxRental.Items.Add(dr.GetString(0));
            }
            dr.Close();
            koneksi.Close();
        }
        private void refreshForm()
        {
            cbID.Text = "";
            cbID.Enabled = false;

            cbNamaPegawai.Text = "";
            cbNamaPegawai.Enabled = false;

            cbHp.Text = "";
            cbHp.Enabled = false;

            cbxRental.Enabled = false;
           
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            button5.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbID.Enabled = true;
            cbNamaPegawai.Enabled = true;
            cbHp.Enabled = true;
            cbxRental.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            button5.Enabled = true;
        }

        private void cbxRental_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string strs = "select kd_rental from dbo.RentalFilm where nama_rental = @nama_rental";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            string selectedName = cbxRental.SelectedItem.ToString();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbID.Text == "")
            {
                MessageBox.Show("ID Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Pegawai values(@id_pegawai, @nama_pegawai, @no_tlp, @kd_rental)", con);
                cmd.Parameters.AddWithValue("@id_pegawai", cbID.Text);
                cmd.Parameters.AddWithValue("@nama_pegawai", cbNamaPegawai.Text);
                cmd.Parameters.AddWithValue("@no_tlp", cbHp.Text);
                cmd.Parameters.AddWithValue("@kd_rental", idRental.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Berhasil Di Simpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshForm();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi = new SqlConnection(stringConnection);
            koneksi.Open();
            SqlCommand cmd = new SqlCommand("delete Pegawai where id_pegawai = @id_pegawai", koneksi);
            cmd.Parameters.AddWithValue("@id_pegawai", cbID.Text);
            cmd.ExecuteNonQuery();
            koneksi.Close();

            MessageBox.Show("Data Berhasil Di Hapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Pegawai set id_pegawai = @id_pegawai, nama_pegawai = @nama_pegawai, no_tlp = @no_tlp, kd_rental = @kd_rental", con);
            cmd.Parameters.AddWithValue("@id_pegawai", cbID.Text);
            cmd.Parameters.AddWithValue("@nama_pegawai", cbNamaPegawai.Text);
            cmd.Parameters.AddWithValue("@no_tlp", cbHp.Text);
            cmd.Parameters.AddWithValue("@kd_rental", idRental.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Berhasil Di Ubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }
    }
}
