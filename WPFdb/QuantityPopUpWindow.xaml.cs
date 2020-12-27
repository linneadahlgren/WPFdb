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
    /// Interaction logic for QuantityPopUpWindow.xaml
    /// </summary>
    public partial class QuantityPopUpWindow : Window
    {
        private int quantity;
        private Button btn;
        private CustomerWindow cb;
        private int topQuantity;
        public QuantityPopUpWindow(CustomerWindow toCallBack, Button btn, int productCode)
        {
            InitializeComponent();
            quantity = 1;
            txtQuantity.Text = quantity.ToString();
            cb = toCallBack;
            this.btn = btn;

            this.topQuantity = ServiceProducts.getAvailableProductQuantity(productCode);
            Console.WriteLine(" top quantity " + topQuantity);
        }



        private void ScrollBar_QuantityChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue < e.OldValue)
            {
                if(quantity < topQuantity)
                    quantity++;
            }
            else
            {
                if (quantity > 1)
                    quantity--;
            }
            txtQuantity.Text = quantity.ToString();
        }

        private void btnConfirm_click(object sender, RoutedEventArgs e)
        {

            cb.setQuantity(quantity, btn);
            this.Close();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            cb.setQuantity(1, btn);
            this.Close();
        }
    }
}
