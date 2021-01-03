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
using System.Data;

namespace WPFdb
{
    /// <summary>
    /// Interaction logic for AdminProductsWindow.xaml
    /// </summary>
    public partial class AdminProductsWindow : Window
    {
        private int quantity = 0;
        private int price = 0;
        private int productCode = -1;

        public AdminProductsWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
    
            tbxQuantity.IsEnabled = false;
            tbxQuantity.Text = quantity.ToString();

            tbxPrice.IsEnabled = false;
            tbxPrice.Text = price.ToString();
            setSupplier(ServiceSupplier.getAllSuppliers());

            loadProductsToDataGrid();
        }

        private void setSupplier(String[] suppliers)
        {
            for (int i = 0; i < suppliers.Length; i++)
            {
                cmboxSuppliers.Items.Add(suppliers[i]);
                System.Diagnostics.Debug.WriteLine("suppliers??? " + suppliers[i]);
            }
        }

        private void btnSelectProduct(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;


            tbxProductName.Text = dataRowView["Product"].ToString();
            cmboxSuppliers.SelectedValue = dataRowView["Supplier"].ToString();
            tbxQuantity.Text = dataRowView["Quanity"].ToString();
            tbxPrice.Text = dataRowView["Price"].ToString();

            quantity = int.Parse(tbxQuantity.Text);
            productCode = int.Parse(dataRowView["Code"].ToString());
        }


        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(sender == scrollbarPrice)
            {
                if (e.NewValue < e.OldValue)
                {
                    price++;
                }
                else
                {
                    if (price > 0)
                        price--;
                }
                tbxPrice.Text = price.ToString();
            }
            else if(sender == scrollBarQuantity)
            {
                if (e.NewValue < e.OldValue)
                    quantity++;
                else
                {
                    if (quantity > 0)
                        quantity--;
                }
                tbxQuantity.Text = quantity.ToString();
            }
           

        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if(sender == btnAddProduct)
            {
                Console.WriteLine("Clicking AddProduct Button");
                Console.WriteLine(tbxQuantity.Text + tbxPrice.Text +"\n"+cmboxSuppliers.Text);
                Boolean isSuccessful = ServiceProducts.addProduct(tbxProductName.Text, cmboxSuppliers.Text, int.Parse(tbxQuantity.Text), int.Parse(tbxPrice.Text));
                if (isSuccessful)
                    clearInputs();
                else
                    Console.WriteLine("Something went wrong");
             
            }
        }

       
     


        private void Discounts_Click(object sender, RoutedEventArgs e)
        {           
                DiscountsWindow discountsWindow = new DiscountsWindow();
                discountsWindow.Show();
                this.Close();
        }
        private void History_Click(object sender, RoutedEventArgs e)
        {
            AdminHistoryWindow history = new AdminHistoryWindow();
            history.Show();
            this.Close();
        }



        private void btn_UpdateQuantity(object sender, RoutedEventArgs e)
        {
            Boolean isSuccessFull = ServiceProducts.updateQuantity(productCode, int.Parse(tbxQuantity.Text));

            if (isSuccessFull)
                clearInputs();
            else
                Console.WriteLine("Something went wrong when updating quantity");
        }

        private void clearInputs()
        {
            productCode = -1;
            quantity = 0;
            price = 0;

            tbxQuantity.Text = "0";
            tbxProductName.Text = "";
            tbxPrice.Text = "0";
            cmboxSuppliers.SelectedIndex = -1;

        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            AdminOrdersWindow ordersWindow = new AdminOrdersWindow();
            ordersWindow.Show();
            this.Close();
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

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            if(ServiceOrders.isProductOrederd(productCode))
                MessageBox.Show("can not delete an ordered product", "info", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                if (productCode != -1 && ServiceProducts.deleteProduct(productCode))
                 {
                    loadProductsToDataGrid();
                    clearInputs();

                }
                else
                    MessageBox.Show("something went wrong deleting a product", "info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void loadProductsToDataGrid()
        {
            dgProducts.DataContext = ServiceProducts.getProductsToDisplayAdmin().DefaultView;

        }

        private void btnShowAdminSearch_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Searching for product " + txtAdminSearchForProducts.Text);
            dgProducts.DataContext = ServiceSearch.searchingForAdminProduct(txtAdminSearchForProducts.Text).DefaultView;
        }
    }
}
