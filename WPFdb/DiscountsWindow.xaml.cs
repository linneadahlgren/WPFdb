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
        private int lowdisconut = 0;
        private int highDiscount = 0;
        public DiscountsWindow()
        {
            InitializeComponent();
            UniversalFunctions.setUpWindow(this);

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

        }

        private void ScrollBar_Discount(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int low = lowdisconut;
            int high = highDiscount;
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
    }
}
