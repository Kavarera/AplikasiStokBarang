using FastWork_AplikasiStokBarang_Y7DMVMY1.models;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.controllers
{
    public class MainController
    {
        MainViews view;
        public UserControllers optionState=null;
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
                if (optionState != null)
                {
                    optionState.CloseView();
                }
                optionState = new BarangKeluarController();
                view.panelContainer.Controls.Clear();
                view.panelContainer.Controls.Add(optionState.GetView());
                view.panelContainer.Controls[0].Dock = DockStyle.Fill;
                //Change option 
                view.panelOptionList.Controls[1].BackColor = Color.FromArgb(97, 168, 127);
                view.panelOptionList.Controls[1].Controls[0].Text = "Pembelian";
                view.panelOptionList.Controls[0].BackColor = Color.White;

                view.panelOptionList.Controls[0].Controls[0].Text = "Barang Masuk";
                view.panelOptionList.Controls[0].Visible = true;
                view.panelOptionList.Controls[1].Visible = true;
            }
            else
            {
                if (optionState != null)
                {
                    optionState.CloseView();
                }
                optionState = new BarangMasukController();
                view.panelContainer.Controls.Clear();
                view.panelContainer.Controls.Add(optionState.GetView());
                view.panelContainer.Controls[0].Dock = DockStyle.Fill;

                //Change option 
                view.panelOptionList.Controls[0].BackColor = Color.FromArgb(97, 168, 127);
                view.panelOptionList.Controls[1].BackColor = Color.White;
                view.panelOptionList.Controls[1].Controls[0].Text = "Pembelian";

                view.panelOptionList.Controls[0].Controls[0].Text = "Barang Masuk";
                view.panelOptionList.Controls[0].Visible = true;
                view.panelOptionList.Controls[1].Visible = true;
            }
        }

        internal void GetHistorySetup()
        {
            optionState = new HistoryController();
            view.panelContainer.Controls.Clear();
            view.panelContainer.Controls.Add(optionState.GetView());
            view.panelContainer.Controls[0].Dock = DockStyle.Fill;

            view.panelOptionList.Controls[0].Visible = false;
            view.panelOptionList.Controls[1].Visible = false;
        }
    }
}
