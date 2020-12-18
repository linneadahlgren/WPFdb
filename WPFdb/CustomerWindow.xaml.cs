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
        }

        public CustomerWindow(Boolean logIn, String userName)
        {
            InitializeComponent();

            UniversalFunctions.setUpWindow(this);
            this.isUserSignedIn = logIn;
            if (this.isUserSignedIn)
            {
                btnCustomerLogInMenu.Visibility = Visibility.Hidden;
                lblSingedInAs.Content = "Signed in as " + userName;
            }

        }

   

        private void CustomerLogInMenu(object sender, RoutedEventArgs e)
        {
            isUserSignedIn = true;

            CustomerLogInMenue logInMenue = new CustomerLogInMenue();
            this.Close();

            logInMenue.Show();

            this.btnCustomerLogInMenu.Visibility = isUserSignedIn ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
        }



    }
}
