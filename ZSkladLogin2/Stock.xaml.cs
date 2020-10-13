using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
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
using ZSKLAD_SRV;
using ZSklad;

namespace ZSkladLogin2
{
    /// <summary>
    /// Interaktionslogik für Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        private string _matnr;
        private Context cOntext;
        private ZSKLAD_SRV_Entities _ctx;
        private readonly Uri _Uri = new Uri("http://srvsapkd1keh.heidrive.loc:8000/sap/opu/odata/sap/ZSKLAD_SRV/");

        public Stock(string matnr, Context context)
        {
            cOntext = context;
            _matnr = matnr;
            InitializeComponent();
            //GetStock();
            Jedem();
        }
        private void GetStock()
        {
           /* _ctx = new ZSKLAD_SRV_Entities(cOntext._Uri);
            _ctx.Credentials = new NetworkCredential(cOntext.user, cOntext.password);
            var x = from o in _ctx.BAPIQUANTSet
                    where o.Whsenumber == "004"
                    && o.Material == _matnr
                    select o;
            var sTock = new DataServiceCollection<BAPIQUANT>(x);
            this.lstwStock.DataContext = sTock;*/
        }
        private void Jedem()
        {

            _ctx = new ZSKLAD_SRV_Entities(_Uri);
            _ctx.Credentials = new NetworkCredential("hrbacek", "Hrbace772");

            // Create a LINQ query that returns customers with related orders.
            var x = from o in _ctx.BAPIQUANTSet
                    where o.Whsenumber == "004"
                    && o.Material == "25-04-01-08-01-0"
                    select o;
            // Create a new collection for binding based on the LINQ query.
            DataServiceCollection<BAPIQUANT> trackedCustomers = new DataServiceCollection<BAPIQUANT>(x);

            // Bind the root StackPanel element to the collection;
            // related object binding paths are defined in the XAML.
            this.lstwStock.DataContext = trackedCustomers;

        }
    }
}
