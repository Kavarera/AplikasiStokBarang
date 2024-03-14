using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWork_AplikasiStokBarang_Y7DMVMY1.models
{
    public abstract class UserControllers
    {
        public abstract UserControl GetView();
        public abstract void CloseView();
    }
}
