using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPFdb
{
   public static class ServiceOrders
    {


        /*
         the String[][] contains the ordered products and the quantity they will be bought in. 
            
             */
        private static Boolean createOrderedProducts(DataTable products, int orderId)
        {
            int productCode;
            double price;
            double quantity;
            double discount;
            String cmd;
            foreach (DataRow row in products.Rows)
            {
                productCode = int.Parse(row["Code"].ToString());
                quantity = double.Parse(row["Qty"].ToString());
                if(row["Discount"].ToString() != "")
                {
                    discount = 1 - (double.Parse(row["Discount"].ToString()) / 100);
                    price = double.Parse(row["Price"].ToString()) * quantity * discount;
                }
                else
                {
                    price = double.Parse(row["Price"].ToString()) * quantity;
                }
                
                cmd = "INSERT INTO OrderedProducts (ProductCode, Price, Quantity, orderId) values (('" + productCode + "'), ('" + (int)price + "'), ('" + quantity + "'), ('" + orderId + "'))";
                if (dbConnection.insertQuery(cmd) == 1)
                    Console.WriteLine("added a orderedproduct with id " + productCode);

            }

            return true;
        }

        public static Boolean customerConfirmOrder(String email, DataTable products)
        {

            String cmd = "INSERT into Orders (Email, isConfirmed, OrderedDate) values (('" + email + "'), 0, ('" + DateTime.Today + "'))";
            Boolean orderedProductId = false;
            if (dbConnection.insertQuery(cmd) == 1)
            {
                cmd = "SELECT TOP 1 * FROM Orders ORDER BY Id DESC";
                int orderId = int.Parse(dbConnection.selectFromRowQuery(cmd).ElementAt(0));
                orderedProductId = createOrderedProducts(products, orderId);

            }



            return false;
        }

        

    }
}
