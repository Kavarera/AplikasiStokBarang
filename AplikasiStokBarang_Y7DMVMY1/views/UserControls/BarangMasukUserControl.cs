using FastWork_AplikasiStokBarang_Y7DMVMY1.controllers;
using FastWork_AplikasiStokBarang_Y7DMVMY1.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls
{
    public partial class BarangMasukUserControl : UserControl
    {
        BarangMasukController controller;
        List<PakanKonserat> listBarang;
        public BarangMasukUserControl(BarangMasukController barangMasukController)
        {
            this.controller = barangMasukController;
            InitializeComponent();
            FillComboBoxWithEnumValues();
            LoadCBBarang();
            UpdateDGV();
        }
        public void FillComboBoxWithEnumValues()
        {
            Array enumValues = Enum.GetValues(typeof(EnumPakanKonserat));

            cbTipe.Items.Clear();
            foreach (EnumPakanKonserat value in enumValues)
            {
                cbTipe.Items.Add(value.ToString()); 
            }
        }

        private void UpdateDGV()
        {
            this.dataGridView1.DataSource = controller.getDGVData();
        }

        private void LoadCBBarang()
        {
            this.listBarang = PakanKonserat.GetPakanFromSql();
            foreach (PakanKonserat a in listBarang)
            {
                cbBarang.Items.Add(a.Nama);
            }
            cbBarang.Text = "Pilih Barang";
        }

        public void CloseView()
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbBarang.SelectedIndex>=0 && textBox1.Text.Length>0)
            {
                //DO UPDATE
                controller.UpdateItem(listBarang.ElementAt(cbBarang.SelectedIndex), textBox1.Text.ToString());
                MessageBox.Show("Update Selesai");
                UpdateDGV();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length>0 && cbTipe.SelectedIndex>=0 && textBox3.Text.Length>0 && textBox4.Text.Length>0)
            {
                //Do Insert
                PakanKonserat pk = new PakanKonserat(
                    textBox4.Text.ToString(),
                    decimal.Parse(textBox2.Text.ToString()),
                    int.Parse(textBox3.Text.ToString()),
                    (EnumPakanKonserat)Enum.Parse(typeof(EnumPakanKonserat), cbTipe.SelectedItem.ToString())
                    );
                controller.InsertItem(pk);
                MessageBox.Show("Menambahkan selesai");
                UpdateDGV();
            }
        }
    }
}
