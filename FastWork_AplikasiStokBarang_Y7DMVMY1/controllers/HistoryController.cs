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
        DataTable historyMasuk = null;
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
                history = new DataTable();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Tambahkan kolom ke DataTable
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        history.Columns.Add(reader.GetName(i));
                    }

                    // Baca hasil query dan tambahkan ke DataTable
                    while (reader.Read())
                    {
                        DataRow row = history.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            if (columnName == "anggota") // Jika nama kolom adalah "anggota"
                            {
                                int tipeValue = reader.GetInt32(i);
                                row[columnName] = tipeValue == 1 ? "YA" : "TIDAK";
                            }
                            else
                            {
                                row[columnName] = reader.GetValue(i);
                            }
                        }
                        history.Rows.Add(row);
                    }
                }
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
                historyMasuk = new DataTable();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Tambahkan kolom ke DataTable
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        historyMasuk.Columns.Add(reader.GetName(i));
                    }

                    // Baca hasil query dan tambahkan ke DataTable
                    while (reader.Read())
                    {
                        DataRow row = historyMasuk.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            if (columnName == "tipe") // Jika nama kolom adalah "tipe"
                            {
                                int tipeValue = reader.GetInt32(i);
                                EnumPakanKonserat tipe = (EnumPakanKonserat)tipeValue;
                                row[columnName] = tipe.ToString();
                            }
                            else
                            {
                                row[columnName] = reader.GetValue(i);
                            }
                        }
                        historyMasuk.Rows.Add(row);
                    }
                }
                return historyMasuk;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
