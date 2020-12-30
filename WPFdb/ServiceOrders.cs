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
        public static List<String[]> getAllOrders()
        {
            String cmd = "SELECT ID, Email, isConfirmed, orderedDate from Orders";

            return dbConnection.selectMultipleRows(cmd);

        }
        public static List<String[]> getOrderedProductsFromOrder(int id)
        {

            String cmd = "SELECT ProductCode, Price, Quantity, OrderID from OrderedProducts where OrderID = ('"+id+"')";

            return dbConnection.selectMultipleRows(cmd);

        }
        

        public static DataTable getOrdersToDisplay()
        {
            List<String[]> list = getAllOrders();
            Console.WriteLine(" hallå " + list.Count);
            DataTable table = new DataTable();
            String[] columnHeader = new String[] { "ID", "Email", "isConfirmed", "orderedDate"};


            foreach (var col in columnHeader)
                table.Columns.Add(col);

            foreach (var array in list)
                table.Rows.Add(array);


            return table;

        }
        public static DataTable getUnconfirmedOrdersFromOrders(DataTable table)
        {
            // DataTable table = allProducts;
            List<int> indexToDelete = new List<int>();
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row[1] + " " + row["isConfirmed"] + " index " + i.ToString());
                if (row["isConfirmed"].ToString() == "True")
                {
                    Console.WriteLine("adding " + i);
                    indexToDelete.Add(i);
                }
                i++;
            }
            int[] fuckoff = indexToDelete.ToArray();

            for (int j = fuckoff.Length - 1; j >= 0; j--)
                table.Rows.RemoveAt(fuckoff[j]);

            return table;
        }

        public static DataTable getOrderSpecsToDisplay(int OrderId)
        {
            List<String[]> list = getOrderedProductsFromOrder(OrderId);
            Console.WriteLine(" hallå " + list.Count);
            DataTable table = new DataTable();
            String[] columnHeader = new String[] { "ProductCode", "Price", "Quantity", "OrderID" };


            foreach (var col in columnHeader)
                table.Columns.Add(col);

            foreach (var array in list)
                table.Rows.Add(array);
           

                return table;

        }
        public static Boolean UpdateIsConfirmed(int OrderId)
        {
            

            String cmd = "update Orders set isConfirmed = 1 where ID = ('" + OrderId + "')";
            if (dbConnection.insertQuery(cmd) == 1)
                return true;

            return false;

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
