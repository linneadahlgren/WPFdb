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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFdb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);

        }

      

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogInWindow adminLogin = new AdminLogInWindow();
            adminLogin.Show();
            this.Close();

        }

        private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerPage = new CustomerWindow();
            customerPage.Show();
            this.Close();
        }

      
    }
}
