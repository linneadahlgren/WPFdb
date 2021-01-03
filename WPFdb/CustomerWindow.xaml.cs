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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private Boolean isUserSignedIn;

        private String currentUserEmail;

        public CustomerWindow()
        {
            InitializeComponent();

            UniversalFunctions.setUpWindow(this);

            this.isUserSignedIn = false;
            
            btnShowProducts.Visibility = Visibility.Hidden;
            btnShowCart.IsEnabled = isUserSignedIn;
            btnOrderHistory.IsEnabled = isUserSignedIn;
            DataGridProducts.DataContext = ServiceProducts.getProductsToDisplay().DefaultView;


        }

        public CustomerWindow(Boolean logIn, String userEmail)
        {
            InitializeComponent();

            UniversalFunctions.setUpWindow(this);
            this.isUserSignedIn = false;

            DataGridProducts.DataContext = ServiceProducts.getProductsToDisplay().DefaultView;
            btnShowProducts.Visibility = Visibility.Hidden;
            btnShowCart.IsEnabled = isUserSignedIn;
            btnOrderHistory.IsEnabled = isUserSignedIn;

            this.isUserSignedIn = logIn;
            currentUserEmail = userEmail;
            if (this.isUserSignedIn)
            {
                btnCustomerLogInMenu.Visibility = Visibility.Hidden;
                lblSingedInAs.Content = "Signed in as " + ServiceCustomer.getNameFromEmail(userEmail);
                btnShowCart.IsEnabled = isUserSignedIn;
                btnOrderHistory.IsEnabled = isUserSignedIn;

            }
            else
            {
                lblSingedInAs.Content = "Login Failed";

            }

        }

        public void setQuantity(int quantity, Button quantityButton)
        {
            quantityButton.Content = "Quantity (" + quantity.ToString() + ")";
            DataRowView dataRowView = (DataRowView)(quantityButton).DataContext;
            dataRowView.BeginEdit();
            dataRowView["Qty"] = quantity.ToString();
            dataRowView.EndEdit();

            DataGridProducts.CommitEdit();




        }

        private void CustomerLogInMenu(object sender, RoutedEventArgs e)
        {
            isUserSignedIn = true;

            CustomerLogInMenue logInMenue = new CustomerLogInMenue();
            this.Close();

            logInMenue.Show();

            this.btnCustomerLogInMenu.Visibility = isUserSignedIn ? Visibility.Hidden : Visibility.Visible;
        }

        private void BtnShowCart_Click(object sender, RoutedEventArgs e)
        {
            DataView data = (DataView) DataGridProducts.ItemsSource;
            DataTable shoppingCart = ServiceProducts.getShoppingListFromSelectedProducts(data.ToTable());
            DataGridProducts.DataContext = shoppingCart.DefaultView;

            double totalPriceOfCart = ServiceProducts.getTotalPriceOfCart(shoppingCart);

            lblTotalPrice.Content = "Total price: " + totalPriceOfCart.ToString();

            btnShowCart.Visibility = Visibility.Hidden;
            btnConfirmOrder.Visibility = Visibility.Visible;
            btnShowProducts.Visibility = Visibility.Visible;

        }

        private void addQuantity_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;



            QuantityPopUpWindow popUp = new QuantityPopUpWindow(this, ((Button)e.Source), int.Parse(dataRowView[0].ToString()));


            popUp.Show();
        }

        

        private void BtnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            DataView data = (DataView)DataGridProducts.ItemsSource;
            
         Boolean isSuccessful =   ServiceOrders.customerConfirmOrder(currentUserEmail, data.ToTable());
            if (isSuccessful)
            {
                DataGridProducts.DataContext = "";
                MessageBox.Show("successfully placed order", "info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("something went wrong when placing order", "info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void btnOrderHistory_Click(object sender, RoutedEventArgs e)
        {

            DataGridProducts.Visibility = Visibility.Hidden;
            dgOrderHistory.Visibility = Visibility.Visible;
            dgOrderHistory.DataContext = ServiceOrders.getCustomerOrderHistoryToDisplay(currentUserEmail).DefaultView;

    
        }

        private void btnCancelOrder_click(object sender, RoutedEventArgs e)
        {

            
            DataRowView dataRow = (DataRowView)((Button)e.Source).DataContext;
            if (dataRow[0].ToString() == "False")
            {
                int orderId = int.Parse(dataRow[1].ToString());
                if (ServiceOrders.cancelOrder(orderId))
                {
                    String info = "successfully cancelled order";
                    String caption = "info";
                    MessageBoxButton boxButton = MessageBoxButton.OK;
                    MessageBoxImage image = MessageBoxImage.Information;
                    MessageBox.Show(info, caption, boxButton, image);
                    dgOrderHistory.DataContext = ServiceOrders.getCustomerOrderHistoryToDisplay(currentUserEmail).DefaultView;
                }

            }
            else
            {
                String info = "you can't cancel a confirmed order";
                String caption = "info";
                MessageBoxButton boxButton = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Information;
                MessageBox.Show(info, caption, boxButton, image);

            }

        }

        private void btnShowProducts_Click(object sender, RoutedEventArgs e)
        {
            dgOrderHistory.Visibility = Visibility.Hidden;
            DataGridProducts.Visibility = Visibility.Visible;
            DataGridProducts.DataContext = ServiceProducts.getProductsToDisplay().DefaultView;
            btnShowCart.Visibility = Visibility.Visible;
            btnConfirmOrder.Visibility = Visibility.Hidden;
            btnShowProducts.Visibility = Visibility.Hidden;


        }

        private void btnShowSearch_Click(object sender, RoutedEventArgs e)
        {
            
                Console.WriteLine("Searching for product " + txtSearch.Text);               
                DataGridProducts.DataContext = ServiceSearch.SearchingForProduct(txtSearch.Text).DefaultView;

        }
    }
}
