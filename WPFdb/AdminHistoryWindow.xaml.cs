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
using System.Windows.Shapes;

namespace WPFdb
{
    /// <summary>
    /// Interaction logic for AdminHistoryWindow.xaml
    /// </summary>
    public partial class AdminHistoryWindow : Window
    {
        public AdminHistoryWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
            btnSeeMonth.IsEnabled = false;

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
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            AdminOrdersWindow ordersWindow = new AdminOrdersWindow();
            ordersWindow.Show();
            this.Close();

        }
        private void Products_Click(object sender, RoutedEventArgs e)
        {
            AdminProductsWindow product = new AdminProductsWindow();
            product.Show();
            this.Close();
        }

        private void SeeMonth_Click(object sender, RoutedEventArgs e)
        {
            String month = "";
            switch (cmboxMonths.Text)
            {
                case "January":
                     month = "01";
                    break;
                case "February":
                    month = "02";
                    break;
                case "March":
                    month = "03";
                    break;
                case "April":
                    month = "04";
                    break;
                case "May":
                    month = "05";
                    break;
                case "June":
                    month = "06";
                    break;
                case "July":
                    month = "07";
                    break;
                case "August":
                    month = "08";
                    break;
                case "September":
                    month = "09";
                    break;
                case "October":
                    month = "10";
                    break;
                case "November":
                    month = "11";
                    break;
                case "December":
                    month = "12";
                    break;
            }
            String year = cmboxYears.Text;
            if (month != "")
            {
                dgHistory.DataContext = ServiceHistory.getOrdersFromSelectedMonthToDisplay(month,year).DefaultView;
            }

            Console.WriteLine(cmboxMonths.Text);
            btnSeeMonth.IsEnabled = false;





        }
        private void cmboxMonths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmboxMonths.SelectedItem != null && cmboxYears.SelectedItem != null)
                btnSeeMonth.IsEnabled = true;

        }
        private void cmboxYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmboxMonths.SelectedItem != null && cmboxYears.SelectedItem != null)
            btnSeeMonth.IsEnabled = true;

        }
    }
}
