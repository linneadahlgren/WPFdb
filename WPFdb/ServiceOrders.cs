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
        public static List<String[]> getOrderedProductsFromOrder(DataRow dataRow)
        {

            String cmd = "SELECT ID, ProductCode, Discount, Price, OrderID, Quantity from OrderedProducts";

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






    }
}
