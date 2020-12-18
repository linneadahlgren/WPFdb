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
    /// Interaction logic for CustomerRegisterWindow.xaml
    /// </summary>
    public partial class CustomerRegisterWindow : Window
    {
        public CustomerRegisterWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
        }
        public CustomerRegisterWindow(String email, String password)
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
            txtLogInEmail.Text = email;
            txtLogInPswrd.Text = password;
        }

        private void BtnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow;
           Boolean isRegistrartionSuccessful = ServiceCustomer.registerNewUser(txtLogInEmail.Text, txtLogInPswrd.Text, txtRegisterFirstName.Text, txtRegisterLastName.Text, txtRegisterAddress.Text, txtRegisterCity.Text, "country", int.Parse(txtRegisterPhoneNumber.Text));

            if (isRegistrartionSuccessful)
                customerWindow = new CustomerWindow(true, txtRegisterFirstName.Text);
            else
                customerWindow = new CustomerWindow(false, "");

            this.Close();
            customerWindow.Show();

     

        }
    }
}
