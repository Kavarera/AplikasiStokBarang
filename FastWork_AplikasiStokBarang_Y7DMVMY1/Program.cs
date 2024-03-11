using FastWork_AplikasiStokBarang_Y7DMVMY1.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainController mc = new MainController();
            Application.Run(mc.GetMainViews());
        }
    }
}
