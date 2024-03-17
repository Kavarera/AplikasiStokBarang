using FastWork_AplikasiStokBarang_Y7DMVMY1.models;
using FastWork_AplikasiStokBarang_Y7DMVMY1.utils;
using FastWork_AplikasiStokBarang_Y7DMVMY1.views.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.controllers
{
    public class BarangKeluarController : UserControllers
    {
        BarangKeluarUserControl _view = null;
        DataTable _dataTable = null;
        
        public BarangKeluarController()
        {
            _view = new BarangKeluarUserControl(this);

        }

        public DataTable getDGVData()
        {

            _dataTable = convertFromList(PakanKonserat.GetPakanFromSql());
            return _dataTable;
        }

        public List<string> LoadAnggota()
        {
            MySqlCommand cmd = new MySqlCommand(
                    "SELECT nama_anggota FROM ANGGOTA", ConnectionUtil.GetConnection());
            List<string> _data = new List<string>();
            try
            {
                ConnectionUtil.OpenConnection();
                using(MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        string te = sdr.GetString(0);
                        _data.Add(te);
                    }
                }
                ConnectionUtil.CloseConnection();
                return _data;
            } catch(Exception e)
            {
                throw e;
            }
        }

        public void InsertOrder(PakanKonserat pk, int banyak, bool anggota=false)
        {
            int a = anggota ? 1 : 0;
            double totalHarga = Double.Parse(pk.Harga.ToString()) * banyak;
            int sisaStok = pk.Stock - banyak;
            MySqlCommand cmd = new MySqlCommand(
                    $"INSERT INTO history(nama_barang, banyak, totalHarga, anggota) VALUES(" +
                    $"\"{pk.Nama}\",{banyak},\"{totalHarga}\",{a})", ConnectionUtil.GetConnection());
            MySqlCommand updateCmd = new MySqlCommand(
                $"UPDATE barang SET stock_barang = {sisaStok} where nama_barang = \"{pk.Nama}\"",ConnectionUtil.GetConnection());

            try
            {
                ConnectionUtil.OpenConnection();
                cmd.ExecuteNonQuery();
                updateCmd.ExecuteNonQuery();
                ConnectionUtil.CloseConnection();
            } catch(Exception e)
            {
                throw e;
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

        public override void CloseView()
        {
            _view.CloseView();
        }

        public override UserControl GetView()
        {
            return _view;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
