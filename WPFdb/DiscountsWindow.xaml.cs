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
    /// Interaction logic for DiscountsWindow.xaml
    /// </summary>
    public partial class DiscountsWindow : Window
    {
        private int discount = 0;
        public DiscountsWindow()
        {
            
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
            String[] products = ServiceProducts.getAllProductsName();
            loadDiscounts();
            for (int i = 0; i < products.Length; i++)
            {
                cmboxProduct.Items.Add(products[i]);
                System.Diagnostics.Debug.WriteLine("suppliers??? " + products[i]);
            }
            DataDiscountHistory.DataContext = ServiceDiscount.getAllDiscountHistoryToDisplay().DefaultView;
        }
        private void loadDiscounts()
        {
            cmboxDiscounts.Items.Clear();
            String[] discountList = ServiceDiscount.getallDiscountNames();

            for (int i = 0; i < discountList.Length; i++)
            {
                cmboxDiscounts.Items.Add(discountList[i]);
                System.Diagnostics.Debug.WriteLine("Discount??? " + discountList[i]);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmboxProdukt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == cmboxProduct)
            {

            }
        }

        private void cmboxDiscounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDiscountPage_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Adding a Discount");
            Boolean isSuccessful = ServiceDiscount.createDiscount(txtDiscountName.Text, int.Parse(tbxDiscount.Text));
            if (isSuccessful)
            {
                Console.WriteLine("Added Discount");
                txtDiscountName.Text = "";
                tbxDiscount.Text = "";
                discount = 0;
                loadDiscounts();
            }
            else{
                Console.WriteLine("FAIL");
            }
        }

        private void ScrollBar_Discount(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(sender == scrollbarDiscount)
            {
                if (e.NewValue < e.OldValue)
                {
                    discount++;
                }

                else
                {
                    if (discount > 0)
                        discount--;
                }
                tbxDiscount.Text = discount.ToString();
            }
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
        private void Product_Click(object sender, RoutedEventArgs e)
        {
            AdminProductsWindow adminWindow = new AdminProductsWindow();
            adminWindow.Show();
            this.Close();
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            AdminOrdersWindow ordersWindow = new AdminOrdersWindow();
            ordersWindow.Show();
            this.Close();

        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            AdminHistoryWindow history = new AdminHistoryWindow();
            history.Show();
            this.Close();
        }


        private void txtDiscountName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDiscountProdcut_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Selected product" + cmboxProduct.SelectedItem.ToString());
            Boolean isSuccessful = ServiceDiscount.discountProduct(cmboxProduct.SelectedItem.ToString(),cmboxDiscounts.SelectedItem.ToString(),txtStartDate.Text,txtEndDate.Text);
            if (isSuccessful)
            {
                Console.WriteLine("Added Discount to product");
                txtEndDate.Text = "";               
                txtStartDate.Text = "";
                cmboxProduct.Text = "";
                cmboxDiscounts.Text = "";
                DataDiscountHistory.DataContext = ServiceDiscount.getAllDiscountHistoryToDisplay().DefaultView;
            }
            else
            {
                Console.WriteLine("FAIL");
            }


        }

        private void DataDiscountHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
