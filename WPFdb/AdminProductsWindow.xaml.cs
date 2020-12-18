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
    /// Interaction logic for AdminProductsWindow.xaml
    /// </summary>
    public partial class AdminProductsWindow : Window
    {
        private int quantity = 0;
        private int price = 0;

        public AdminProductsWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);
    
            tbxQuantity.IsEnabled = false;
            tbxQuantity.Text = quantity.ToString();

            tbxPrice.IsEnabled = false;
            tbxPrice.Text = price.ToString();
            
            System.Diagnostics.Debug.WriteLine("suppliers??? "+  ServiceSupplier.getAllSuppliers().Length);


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
                {
                    System.Diagnostics.Debug.WriteLine("vad får vi??? " + e.NewValue.ToString());
                    System.Diagnostics.Debug.WriteLine("vad får vi??? " + e.OldValue.ToString());

                    quantity++;

                }
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

        }
    }
}
