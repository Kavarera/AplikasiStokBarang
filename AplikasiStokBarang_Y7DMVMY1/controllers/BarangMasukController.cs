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
    public class BarangMasukController : UserControllers
    {
        BarangMasukUserControl _view = null;
        DataTable _dataTable = null;

        public BarangMasukController()
        {
            _view = new BarangMasukUserControl(this);
        }

        public override void CloseView()
        {
            _view.CloseView();
        }

        public override UserControl GetView()
        {
            return this._view;
        }

        internal DataTable getDGVData()
        {
            _dataTable = convertFromList(PakanKonserat.GetPakanFromSql());
            return _dataTable;
        }

        internal void InsertItem(PakanKonserat pk)
        {
            MySqlCommand cmd = new MySqlCommand(
                    $"INSERT INTO barang(nama_barang, stock_barang,tipe_barang, harga) VALUES(" +
                    $"\"{pk.Nama}\",{pk.Stock},{(int)pk.Tipe},{pk.Harga})", ConnectionUtil.GetConnection());
            try
            {
                ConnectionUtil.OpenConnection();
                cmd.ExecuteNonQuery();
                ConnectionUtil.CloseConnection();
            } catch(Exception e)
            {
                throw e;
            }
        }

        internal void UpdateItem(PakanKonserat pakanKonserat, string v)
        {
            MySqlCommand updateCmd = new MySqlCommand(
                 $"UPDATE barang SET stock_barang = {v} where nama_barang = \"{pakanKonserat.Nama}\"", ConnectionUtil.GetConnection());
            MySqlCommand cmd = new MySqlCommand(
                    $"INSERT INTO history_masuk(nama, tipe, banyak) VALUES(" +
                    $"\"{pakanKonserat.Nama}\",\"{(int)pakanKonserat.Tipe}\",{v})", ConnectionUtil.GetConnection());
            try
            {
                ConnectionUtil.OpenConnection();
                updateCmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                ConnectionUtil.CloseConnection();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable convertFromList(List<PakanKonserat> pakanKonserats)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nama", typeof(string));
            dataTable.Columns.Add("Harga", typeof(decimal));
            dataTable.Columns.Add("Stock", typeof(int));
            dataTable.Columns.Add("Tipe", typeof(EnumPakanKonserat));
            foreach (PakanKonserat pakan in pakanKonserats)
            {
                dataTable.Rows.Add(pakan.Nama, pakan.Harga, pakan.Stock, pakan.Tipe);
            }
            return dataTable;
        }
    }
}
