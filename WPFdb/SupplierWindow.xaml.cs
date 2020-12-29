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
    /// Interaction logic for SupplierWindow.xaml
    /// </summary>
    public partial class SupplierWindow : Window
    {
        public SupplierWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
        }

        private void BtnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            String name = tbxSupplierName.Text;
            String phonenbr = tbxSupplierphnNbr.Text;
            String address = tbxSupplierAddress.Text;

            Boolean isSuccessfulInsert = ServiceSupplier.addSupplier(name, int.Parse(phonenbr), address);

            if (isSuccessfulInsert)
            {
                tbxSupplierAddress.Clear();
                tbxSupplierName.Clear();
                tbxSupplierphnNbr.Clear();
            }

        }

       private void AdminProductsItem_Click(object sender, RoutedEventArgs e)
        {
            AdminProductsWindow adminWindow = new AdminProductsWindow();
            adminWindow.Show();
            this.Close();
        }

        private void AdminSupplierItem_Click(object sender, RoutedEventArgs e)
        {
                SupplierWindow supplier = new SupplierWindow();
                supplier.Show();
                this.Close();          
        }
        private void AdminDiscountItem_Click (object sender, RoutedEventArgs e)
        {
            DiscountsWindow discountsWindow = new DiscountsWindow();
            discountsWindow.Show();
            this.Close();
        }
    }
}
