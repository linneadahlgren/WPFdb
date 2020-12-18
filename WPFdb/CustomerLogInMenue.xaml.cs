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
using System.Data.SqlClient;


namespace WPFdb
{
    /// <summary>
    /// Interaction logic for CustomerLogInMenue.xaml
    /// </summary>
    public partial class CustomerLogInMenue : Window
    {
        public CustomerLogInMenue()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
            
        }

        private void BtnLogInCostumer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow costumerWindow; // här vill vi kolla med db att man faktiskt har blivit inloggad. 

            String userEmail = txtLogInEmail.Text;
            String password = txtLogInPswrd.Text;
            System.Diagnostics.Debug.WriteLine(" skickar med till db: " + userEmail);

            if (ServiceCustomer.isUserCredentialsCorrect(userEmail, password))
            {
                costumerWindow = new CustomerWindow(true, ServiceCustomer.getNameFromEmail(userEmail));
                System.Diagnostics.Debug.WriteLine(" user can sign in ");

            }
            else
            {
                costumerWindow = new CustomerWindow(false, "");
                System.Diagnostics.Debug.WriteLine(" user can not sign in ");

            }

            this.Close();
            costumerWindow.Show();
        } 

        private void BtnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            CustomerRegisterWindow registerWindow;

            if (txtLogInEmail.Text.Length > 1 || txtLogInPswrd.Text.Length > 1)
                registerWindow = new CustomerRegisterWindow(txtLogInEmail.Text, txtLogInPswrd.Text);
            else
                registerWindow = new CustomerRegisterWindow();

            this.Close();
            registerWindow.Show();
       
        }
    }
}
