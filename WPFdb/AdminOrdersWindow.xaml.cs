using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Data;

namespace WPFdb
{
    /// <summary>
    /// Interaction logic for AdminOrdersWindow.xaml
    /// </summary>
    public partial class AdminOrdersWindow : Window
    {
        public AdminOrdersWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
            btnConfirmOrder.Visibility = Visibility.Hidden;

            dgProducts.DataContext = ServiceOrders.getOrdersToDisplay();
        }
        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            SupplierWindow supplier = new SupplierWindow();
            supplier.Show();
            this.Close();
        }
        private void Discounts_Click(object sender, RoutedEventArgs e)
        {
            DiscountsWindow discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
            this.Close();
        }
        private void btnSelectOrder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int ID = int.Parse(dataRowView["ID"].ToString());
            dgOrderSpecs.DataContext = ServiceOrders.getOrderSpecsToDisplay(ID).DefaultView;
            btnConfirmOrder.Visibility = Visibility.Visible;

            Console.WriteLine("testclick");
        }

        private void btnSeeAllOrders_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
