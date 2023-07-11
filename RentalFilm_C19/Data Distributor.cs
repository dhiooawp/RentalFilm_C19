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
    public partial class Distributor : Form
    {
        private string stringConnection = "data source=BRAINWASH\\DHIOAWP;" + "database=RentalFilm; User ID=sa;Password=240503Xx";
        private SqlConnection koneksi;
        public Distributor()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshForm();
        }
        
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from Distributor";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void refreshForm()
        {
            tbKode.Text = "";
            tbAlamat.Text = "";
            tbDistributor.Text = "";
            tbHp.Text = "";
            tbKode.Enabled = false;
            tbAlamat.Enabled = false;
            tbDistributor.Enabled = false;
            tbHp.Enabled = false;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnDisplay.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbKode.Enabled = true;
            tbAlamat.Enabled = true;
            tbDistributor.Enabled = true;
            tbHp.Enabled = true;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnDisplay.Enabled = true;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbKode.Text == "")
            {
                MessageBox.Show("Kode Distributor Tidak Boleh Kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Distributor values(@kd_distributor, @nama, @alamat, @no_tlp)", con);
                cmd.Parameters.AddWithValue("@kd_distributor", tbKode.Text);
                cmd.Parameters.AddWithValue("@nama", tbDistributor.Text);
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
            SqlCommand cmd = new SqlCommand("update Distributor set kd_distributor = @kd_distributor, nama = @nama, alamat = @alamat, no_tlp = @no_tlp", con);
            cmd.Parameters.AddWithValue("@kd_distributor", tbKode.Text);
            cmd.Parameters.AddWithValue("@nama", tbDistributor.Text);
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
            koneksi.Open();
            SqlCommand cmd = new SqlCommand("delete Film where kd_film=@kd_film", koneksi);
            cmd.Parameters.AddWithValue("@kd_film", tbKode.Text);
            cmd.ExecuteNonQuery();
            koneksi.Close();

            MessageBox.Show("Data Berhasil Di Hapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshForm();
        }
    }
}
