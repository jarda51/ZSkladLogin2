using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZSklad;
using ZSKLAD_SRV;

namespace ZSkladLogin2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private int _wrongPassword = 1;
        private Login _login;
        private Context _Context;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                _login = new Login();
                if (_login.ShowDialog() == true)
                {
                    _Context = new Context(_login.txtBox.Text.ToString(), _login.lblPasswordBox.Password.ToString());
                    _login.Close();
                    //MessageBox.Show("přihlášení je v pořádku");
                    new MainWindow(_Context).ShowDialog();
                }
                else
                {
                    MessageBox.Show("přihlášení selhalo");
                    _wrongPassword = ++_wrongPassword;
                     if (_wrongPassword > 2)
                    {
                        MessageBox.Show("přihlášení selhalo již 3x!!!!!");
                        Shutdown();
                    }
                }
            }
            finally
            {
                Shutdown();
            }
        }
    }
}
