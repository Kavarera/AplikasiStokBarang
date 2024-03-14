using FastWork_AplikasiStokBarang_Y7DMVMY1.models;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls;
using System.Drawing;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.controllers
{
    public class MainController
    {
        MainViews view;
        public UserControllers optionState;
        public MainController() { 
        }
        public Form GetMainViews()
        {
            view = new MainViews(this);
            return view;
        }

        public void GetBarangUC(int result)
        {
            if (result == 1)
            {
                optionState = new BarangKeluarController();
                view.panelContainer.Controls.Clear();
                view.panelContainer.Controls.Add(optionState.GetView());
                view.panelContainer.Controls[0].Dock = DockStyle.Fill;
                //Change option 
                view.panelOptionList.Controls[1].BackColor = Color.FromArgb(97, 168, 127);
                view.panelOptionList.Controls[1].Controls[0].Text = "Pembelian";
                view.panelOptionList.Controls[0].BackColor = Color.White;

                view.panelOptionList.Controls[0].Controls[0].Text = "Barang Masuk";

                optionState = new BarangKeluarController();
            }
            else
            {
                optionState = new BarangMasukController();
                view.panelContainer.Controls.Clear();
                view.panelContainer.Controls.Add(optionState.GetView());
                view.panelContainer.Controls[0].Dock = DockStyle.Fill;

                //Change option 
                view.panelOptionList.Controls[0].BackColor = Color.FromArgb(97, 168, 127);
                view.panelOptionList.Controls[1].BackColor = Color.White;
                view.panelOptionList.Controls[1].Controls[0].Text = "Pembelian";

                view.panelOptionList.Controls[0].Controls[0].Text = "Barang Masuk";
            }
        }

        
    }
}
