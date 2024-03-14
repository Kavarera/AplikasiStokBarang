using FastWork_AplikasiStokBarang_Y7DMVMY1.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.models
{
    public class PakanKonserat
    {
        public string Nama { get; set; }
        public decimal Harga { get; set; }
        public int Stock { get; set; }
        public EnumPakanKonserat Tipe { get; set; }
        public PakanKonserat(string nama, decimal harga, int stock, EnumPakanKonserat tipe)
        {
            Nama = nama;
            Harga = harga;
            Stock = stock;
            Tipe = tipe;
        }

        public static List<PakanKonserat> GetPakanFromSql()
        {
            try
            {
                List<PakanKonserat> pakanList = new List<PakanKonserat>();
                ConnectionUtil.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT nama_barang as \"Barang\",Harga, stock_barang" +
                    " as \"Stock\",tipe_barang as \"Tipe\" FROM BARANG ORDER BY STOCK_BARANG DESC", ConnectionUtil.GetConnection());
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string nama = sdr.GetString(0);
                    decimal harga = sdr.GetDecimal(1);
                    int stock = sdr.GetInt32(2);
                    EnumPakanKonserat tipe = (EnumPakanKonserat)sdr.GetInt32(3);
                    PakanKonserat pakan = new PakanKonserat(nama, harga, stock, tipe);
                    pakanList.Add(pakan);
                }
                sdr.Close();
                ConnectionUtil.CloseConnection();
                return pakanList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
