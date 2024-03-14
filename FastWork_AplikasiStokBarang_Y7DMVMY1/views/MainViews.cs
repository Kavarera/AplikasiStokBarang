using FastWork_AplikasiStokBarang_Y7DMVMY1.controllers;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.views
{
    public partial class MainViews : Form
    {
        MainController controller = new MainController();
        public MainViews(MainController mc)
        {
            InitializeComponent();
            this.controller = mc;
        }

        private void panelBarang_DoubleClick(object sender, EventArgs e)
        {
            panelBarang.BackColor = Color.FromArgb(97, 168, 127);//active
            panelHistory.BackColor = Color.FromArgb(97, 215, 146);
            //run controller setup
            controller.GetBarangUC(1);

        }

        private void panelHistory_DoubleClick(object sender, EventArgs e)
        {
            panelBarang.BackColor = Color.FromArgb(97, 215, 146);
            panelHistory.BackColor = Color.FromArgb(97, 168, 127);//active

            //Run controller setup for history
            controller.GetHistorySetup();
        }

        private void panelOption2_Click(object sender, EventArgs e)
        {
            if (controller.optionState !=null)
            {
                controller.GetBarangUC(2);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (controller.optionState != null)
            {
                controller.GetBarangUC(1);
            }
        }
    }
}
