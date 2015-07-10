using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Security;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace WindowsFormsApplication2
{
    public partial class Executando : Form
    {
        public Executando()
        {
            InitializeComponent();
        }

     

        private void Executando_Load_1(object sender, EventArgs e)
        {
            Registro r = new Registro();
            r.Registra();
            MessageBox.Show("Executando");
        }
    }
}
