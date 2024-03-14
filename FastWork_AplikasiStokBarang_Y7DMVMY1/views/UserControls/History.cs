using FastWork_AplikasiStokBarang_Y7DMVMY1.controllers;
using System;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls
{
    public partial class History : UserControl
    {
        HistoryController controller;
        public History(HistoryController c)
        {
            this.controller = c;
            InitializeComponent();
            LoadDGV();
        }

        private void LoadDGV()
        {
            dataGridView2.DataSource = controller.getDGVHistoryMasuk();
            dataGridView1.DataSource = controller.getDGVHistoryKeluar();
        }

        public void CloseView()
        {
            this.Dispose();
        }
    }
}
