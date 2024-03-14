using FastWork_AplikasiStokBarang_Y7DMVMY1.models;
using FastWork_AplikasiStokBarang_Y7DMVMY1.utils;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.controllers
{
    public class HistoryController : UserControllers
    {
        History _view = null;
        DataTable history=null;
        public HistoryController()
        {
            this._view = new History(this);
        }
        public override void CloseView()
        {
            _view.CloseView();
        }

        public override UserControl GetView()
        {
            return _view;
        }

        public DataTable getDGVHistoryKeluar()
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT nama_barang, banyak, totalHarga, anggota FROM HISTORY", ConnectionUtil.GetConnection());
            try
            {
                ConnectionUtil.OpenConnection();
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                history = new DataTable();
                sda.Fill(history);
                return history;
            } catch(Exception e)
            {
                throw e;
            }
        }
        public DataTable getDGVHistoryMasuk()
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT nama, tipe, banyak FROM history_masuk", ConnectionUtil.GetConnection());
            try
            {
                ConnectionUtil.OpenConnection();
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                history = new DataTable();
                sda.Fill(history);
                return history;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
