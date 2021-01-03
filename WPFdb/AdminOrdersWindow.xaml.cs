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
            btnConfirmOrder.IsEnabled = false;
            btnSeeUnconfirmedOrders.IsEnabled = false;

            dgOrders.DataContext = ServiceOrders.getOrdersToDisplay();
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
        private void Products_Click(object sender, RoutedEventArgs e)
        {
            AdminProductsWindow product = new AdminProductsWindow();
            product.Show();
            this.Close(); 
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            AdminHistoryWindow history = new AdminHistoryWindow();
            history.Show();
            this.Close();
        }

        private void btnSelectOrder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int ID = int.Parse(dataRowView["ID"].ToString());
            dgOrderSpecs.DataContext = ServiceOrders.getOrderSpecsToDisplay(ID).DefaultView;
            
        }
        private void btnSeeAllOrders_Click(object sender, RoutedEventArgs e)
        {
            dgOrders.DataContext = ServiceOrders.getOrdersToDisplay().DefaultView;
        }

        private void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (DataRowView)((Button)e.Source).DataContext;
            int OrderID = int.Parse(data["OrderID"].ToString());
            Boolean isSuccesful = ServiceOrders.UpdateIsConfirmed(OrderID);
            if(isSuccesful)
            {
                dgOrderSpecs.DataContext = null;
                btnConfirmOrder.IsEnabled = false;
                dgOrders.DataContext = ServiceOrders.getOrdersToDisplay().DefaultView;
            }
            else
            {
                Console.WriteLine("error with confirming order");
            }
           
        }
    }
}
