using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPFdb
{
    class ServiceHistory
    {
        public static List<String[]> getAllOrdersForSelectedMonth(String month, String year)
        {
            Console.WriteLine(month);
            String cmd = "select Orders.ID, Products.Name, Orders.orderedDate sum(OrderedProducts.Quantity)[Amount Ordered] from orders join OrderedProducts on orders.ID = OrderedProducts.OrderID join Products on OrderedProducts.ProductCode = Products.Code where orderedDate like '_____10___'";


            String cmd1 = "select Orders.ID, Products.Name, Orders.orderedDate,sum(OrderedProducts.Quantity) from orders join OrderedProducts on orders.ID = OrderedProducts.OrderID join Products on OrderedProducts.ProductCode = Products.Code where orderedDate like '" + year+"-" + month + "___' group by Orders.ID, Products.Name, Orders.orderedDate";
            Console.WriteLine(cmd1);
            return dbConnection.selectMultipleRows(cmd1);

        }

        public static DataTable getOrdersFromSelectedMonthToDisplay(String month, String year)
        {
            List<String[]> list = getAllOrdersForSelectedMonth(month,year);
            Console.WriteLine(" hallå " + list.Count);
            DataTable table = new DataTable();
            String[] columnHeader = new String[] { "Order ID", "Product Name", "Ordered Date", "Total Ordered" };


            foreach (var col in columnHeader)
                table.Columns.Add(col);

            foreach (var array in list)
                table.Rows.Add(array);


            return table;

        }


    }
}
