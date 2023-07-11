using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalFilm_C19
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void filmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Film fl = new Film();
            fl.ShowDialog();
            
        }

        private void rentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rental rt = new Rental();
            rt.Show();
            
        }

        private void informasiBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barang br = new Barang();
            br.Show();
            
        }

        private void stokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stok st = new Stok();
            st.Show();
  
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi tr = new Transaksi();
            tr.Show();
            
        }

        private void distributorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Distributor dtr = new Distributor();
            dtr.Show();
            
        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pegawai pg = new Pegawai();
            pg.Show();
            
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pelanggan plg = new Pelanggan();
            plg.Show();
            
        }
    }
}
