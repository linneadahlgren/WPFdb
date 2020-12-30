﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPFdb
{
   public static class ServiceOrders
    {


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

        public static DataTable getCustomerOrderHistoryToDisplay(String email)
        {
            List<String[]> orders = getCustomerOrderHistory(email);
            DataTable table = new DataTable();
            String[] colHeader = new string[] { "is confirmed", "orderId", "Ordered Date" };
            foreach (var col in colHeader)
                table.Columns.Add(col);

            foreach (var order in orders)
                table.Rows.Add(order);

            return table;
        }

        public static Boolean cancelOrder(int orderId)
        {
            String cmd = "DELETE FROM Orders where id = ('"+orderId+"')";
            if (cancelProducts(orderId))
                if (dbConnection.insertQuery(cmd) == 1)
                    return true;


            return false;
        }

        private static Boolean cancelProducts(int orderID)
        {
            String cmd = "SELECT productCode, Quantity from OrderedProducts where orderId = ('" + orderID + "')";

            List<String[]> orderedProducts = dbConnection.selectMultipleRows(cmd);


            cmd = "DELETE FROM  OrderedProducts where orderid = ('" + orderID + "')";

            if (dbConnection.insertQuery(cmd) > 0)
                if(restoreQuantity(orderedProducts))
                    return true;
         
            return false;
        }

        private static Boolean restoreQuantity(List<String[]> orderedProducts)
        {
            String cmd;
            String productCode;
            String quantity;

            Boolean isSuccessful = false;

            foreach(String[] product in orderedProducts)
            {
                productCode = product[0];
                quantity = product[1];
                cmd = "UPDATE Products set Quantity = (SELECT Quantity from products where code = ('" + productCode + "'))+('" + quantity + "') Where code = ('" + productCode + "')";
                if (dbConnection.insertQuery(cmd) == 1)
                    isSuccessful = true;
                else
                    isSuccessful = false;
            }

            return isSuccessful;
        }

        private static List<String[]> getCustomerOrderHistory(String email)
        {
            String cmd = "SELECT isConfirmed, id, orderedDate from Orders WHERE email = ('" + email + "')";
            List<String[]> orders = dbConnection.selectMultipleRows(cmd);
      
            

            return orders;
        }

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
                if (row["Discount"].ToString() != "")
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
                {
                    Console.WriteLine("added a orderedproduct with id " + productCode);
                    cmd = "UPDATE Products set Quantity = (SELECT Quantity from products where code = ('" + productCode + "'))-('" + quantity + "') Where code = ('" + productCode + "')";
                    dbConnection.insertQuery(cmd);
                }


            }

            return true;
        }


    }
}
