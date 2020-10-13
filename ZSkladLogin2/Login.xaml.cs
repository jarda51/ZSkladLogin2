using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZSklad;
using ZSKLAD_SRV;

namespace ZSkladLogin2
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public ZSklad.Context check_user { get; set; }
        public Login()
        {
            InitializeComponent();
        }
        private async void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                check_user = new ZSklad.Context(txtBox.Text, lblPasswordBox.Password);
                bool check_credentials =  await check_user.CheckCredentials();
                this.DialogResult = true;
                //this.Close();
            }
        }

        private async void btPassword_Click(object sender, RoutedEventArgs e)
        {
            ZSklad.Context check_user = new ZSklad.Context(txtBox.Text, lblPasswordBox.Password);
            bool check_credentials = await check_user.CheckCredentials();

            if (check_credentials)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("přihlášení selhalo");
            }
        }
    }
}
