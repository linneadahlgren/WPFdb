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
    /// Interaction logic for AdminLogInWindow.xaml
    /// </summary>
    public partial class AdminLogInWindow : Window
    {
        public AdminLogInWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SerivceAdmin.canAdminLogIn(txtAdminUserName.Text, txtAdminPassword.Text))
            {
                AdminProductsWindow adminWindow = new AdminProductsWindow();
                this.Close();
                adminWindow.Show();

            }
            else
            {
                MainWindow mainWind = new MainWindow();
                this.Close();
                mainWind.Show();
            }

        }
    }
}
