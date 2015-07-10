using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WindowsFormsApplication2
{
    public class Ping1
    {
        static bool taok = false;

        internal static bool IsAlive(String Host){
            
            Ping senderPing = new Ping();
            
            AutoResetEvent waiter = new AutoResetEvent (false);

            senderPing.PingCompleted += new PingCompletedEventHandler (PingCompletedCallback);

            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);

            int timeout = 10000;

            PingOptions options = new PingOptions(64,true);

            senderPing.SendAsync(Host, timeout, buffer, options, waiter);
            return taok;
        }


        private static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            // If the operation was canceled, display a message to the user.
            if (e.Cancelled)
            {
                Console.WriteLine("Ping canceled.");

                // Let the main thread resume. 
                // UserToken is the AutoResetEvent object that the main thread 
                // is waiting for.
                ((AutoResetEvent)e.UserState).Set();
            }

            // If an error occurred, display the exception to the user.
            if (e.Error != null)
            {
                Console.WriteLine("Ping failed:");
                Console.WriteLine(e.Error.ToString());

                // Let the main thread resume. 
                ((AutoResetEvent)e.UserState).Set();
            }

            PingReply reply = e.Reply;

            RegistraKey(reply);

            // Let the main thread resume.
            ((AutoResetEvent)e.UserState).Set();
        }

        public static void RegistraKey(PingReply reply)
        {
            if (reply == null)
                return;

            if (reply.Status == IPStatus.Success)
            {
                //aqui entra o code do registro com o code exceções e etc
                //a classe para pegar o endereço é reply.Address.ToString()
                //
                const String userRoot = "HKEY_CURRENT_USER";
                const String Proxy = userRoot + "\\" + "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
                string serv = reply.Address.ToString() + ":3128";
                string excecoes = "10*;*.taskrj.msft;*.suframa.gov.br*;*.confitec.*;taskrj.cjb.net;*forponto.com*;*.tasksistemas.*;*.kaba-idms.net*;*portalerp.itau.com.br;vpnportal.carrefour.com;remotoweb.votorantim.com.br;*hfm2.kaba.grp*;*cms.kaba.net*;<local>";

                Registry.SetValue(Proxy, "ProxyEnable", 1); 
                Registry.SetValue(Proxy, "ProxyServer", serv);
                Registry.SetValue(Proxy, "ProxyOverride", excecoes);
                taok = true;
            }
        }

       


        
        
    }
}
