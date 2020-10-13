using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZSklad;
using ZSKLAD_SRV;

namespace ZSkladLogin2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ZSklad.Context ctx;
        public MainWindow(ZSklad.Context context)
        {
            ctx = context;
            InitializeComponent();
        }

        private void btStock_Click(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock(txMatnr.ToString(), ctx);
            stock.Show();
        }
    }
}
