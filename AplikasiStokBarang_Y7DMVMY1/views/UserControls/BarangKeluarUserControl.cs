using FastWork_AplikasiStokBarang_Y7DMVMY1.controllers;
using FastWork_AplikasiStokBarang_Y7DMVMY1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls
{
    public partial class BarangKeluarUserControl : UserControl
    {
        private BarangKeluarController controller;
        List<PakanKonserat> listBarang;
        public BarangKeluarUserControl(BarangKeluarController bc)
        {
            this.controller = bc;
            InitializeComponent();
            UCSetup();
        }

        private void UCSetup()
        {
            UpdateDGV();
            LoadCBBarang();
        }

        private void LoadCBBarang()
        {
            this.listBarang = PakanKonserat.GetPakanFromSql();
            foreach(PakanKonserat a in listBarang)
            {
                cbBarang.Items.Add(a.Nama);
            }
            cbBarang.Text = "Pilih Barang";
        }

        private void UpdateDGV()
        {
            this.dataGridView1.DataSource = controller.getDGVData();
        }
        public void CloseView()
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            updateLabelTotal();
        }

        private void tbNamaPembeli_Enter(object sender, EventArgs e)
        {
            if(tbNamaPembeli.Text=="Nama Pembeli")
            {
                tbNamaPembeli.Clear();
            }
        }

        private void tbNamaPembeli_Leave(object sender, EventArgs e)
        {
            if (tbNamaPembeli.TextLength==0)
            {
                tbNamaPembeli.Text = "Nama Pembeli";
            }
        }

        private void cbBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblHarga.Text = "Rp. " + listBarang.ElementAt(cbBarang.SelectedIndex).Harga;
            updateLabelTotal();
        }

        private void updateLabelTotal()
        {
            if (cbBarang.SelectedIndex < 0)
            {
                return;
            }
            if (listBarang.ElementAt(cbBarang.SelectedIndex).Nama.Contains("Regular"))
            {
                if (checkBox1.Checked)
                {
                    lblTotal.Text = "Rp. " 
                        + (listBarang.ElementAt(cbBarang.SelectedIndex).Harga * int.Parse(textBox2.Text.ToString())
                        - (15000*int.Parse(textBox2.Text.ToString()))).ToString();
                }
                else
                {
                    lblTotal.Text = "Rp. " + listBarang.ElementAt(cbBarang.SelectedIndex).Harga
                        * int.Parse(textBox2.Text.ToString());
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    lblTotal.Text = "Rp. " + (listBarang.ElementAt(cbBarang.SelectedIndex).Harga
                        *int.Parse(textBox2.Text.ToString()) 
                        - (25000*int.Parse(textBox2.Text.ToString()))).ToString();
                }
                else
                {
                    MessageBox.Show(listBarang.ElementAt(cbBarang.SelectedIndex).Harga.ToString());
                    lblTotal.Text = "Rp. " + listBarang.ElementAt(cbBarang.SelectedIndex).Harga
                        * int.Parse(textBox2.Text.ToString());
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            updateLabelTotal();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
            }
            if (textBox2.Text.Length == 1 && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                textBox2.Text = "1";
            }
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            controller.InsertOrder(listBarang.ElementAt(cbBarang.SelectedIndex),
                int.Parse(textBox2.Text.ToString()),checkBox1.Checked);
            tbNamaPembeli.Text = "Nama Pembeli";
            checkBox1.Checked = true;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            tbNamaPembeli.Clear();
            checkBox1.Checked = true;
        }
    }
}
