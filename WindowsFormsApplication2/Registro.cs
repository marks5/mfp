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
    class Registro
    {
       
        public void Registra()
{

        const String userRoot = "HKEY_CURRENT_USER";
        const String Proxy = userRoot + "\\" + "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        
        
            
            while (true) {
                if (Ping1.IsAlive("10.142.0.1") == true) { MessageBox.Show("RJ"); break; }

                if (Ping1.IsAlive("10.142.8.5") == true) { MessageBox.Show("SP"); break; }
                if (Ping1.IsAlive("10.142.7.1") == true) { MessageBox.Show("PR"); break; }
                if (Ping1.IsAlive("10.142.4.1") == true) { MessageBox.Show("PN"); break; }
                if (Ping1.IsAlive("10.142.5.1") == true) { MessageBox.Show("tst"); break; }
            
            Registry.SetValue(Proxy, "ProxyEnable", 0);
                break;

            };
            
                
                

        }
    }
}
