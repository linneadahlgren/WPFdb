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

        

        public CustomerWindow()
        {
            InitializeComponent();

            UniversalFunctions.setUpWindow(this);

            this.isUserSignedIn = false;

            btnShowCart.IsEnabled = isUserSignedIn;
            DataGridProducts.DataContext = ServiceProducts.getProductsToDisplay().DefaultView;


        }

        public CustomerWindow(Boolean logIn, String userName)
        {
            InitializeComponent();

            UniversalFunctions.setUpWindow(this);

            DataGridProducts.DataContext = ServiceProducts.getProductsToDisplay().DefaultView;

            this.isUserSignedIn = logIn;
            if (this.isUserSignedIn)
            {
                btnCustomerLogInMenu.Visibility = Visibility.Hidden;
                lblSingedInAs.Content = "Signed in as " + userName;
                btnShowCart.IsEnabled = isUserSignedIn;
            }

        }

        public void setQuantity(int quantity, Button quantityButton)
        {
            quantityButton.Content = "Quantity (" + quantity.ToString() + ")"; 

        }

        private void CustomerLogInMenu(object sender, RoutedEventArgs e)
        {
            isUserSignedIn = true;

            CustomerLogInMenue logInMenue = new CustomerLogInMenue();
            this.Close();

            logInMenue.Show();

            this.btnCustomerLogInMenu.Visibility = isUserSignedIn ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
        }

        private void BtnShowCart_Click(object sender, RoutedEventArgs e)
        {
            DataView data = (DataView) DataGridProducts.ItemsSource;
           
            DataGridProducts.DataContext = ServiceProducts.getShoppingListFromSelectedProducts(data.ToTable()).DefaultView;

            btnShowCart.Visibility = Visibility.Hidden;
            btnConfirmOrder.Visibility = Visibility.Visible;
        }

        private void addQuantity_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            Console.WriteLine(" nu ska vi lägga till quantity " + dataRowView[0].ToString());

            QuantityPopUpWindow popUp = new QuantityPopUpWindow(this, ((Button)e.Source), int.Parse(dataRowView[0].ToString()));

            popUp.Show();
        }

        

        private void BtnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
