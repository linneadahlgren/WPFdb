using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace WPFdb
{
    public static class ServiceSearch
    {
        public static DataTable SearchingForProduct(String search)
        {
            List<String[]> list = searching(search);
            DataTable searchTable = new DataTable();
            String[] column = new string[] { "Code", "Product name", "Price", "Supplier","Discounts"};

            foreach (var col in column)
                searchTable.Columns.Add(col);

            foreach (var array in list)
                searchTable.Rows.Add(array);

            return searchTable;
        }
        public static List<String[]> searching(String search)
        {

            Console.WriteLine("Testar" + search);
            String cmd;
            if (search == "")
            {
                return ServiceProducts.getAllProductsIncludingDiscount();


            }
            else
            {
                //cmd = "select Code,Name,Price,Supplier from Products where name like " + "'%" + search + "%'";
               cmd = "SELECT P.code, P.name, P.price, P.supplier, Discount.Precentage from Products as P FULL OUTER JOIN ActiveDiscounts on p.code = ActiveDiscounts.productCode FULL OUTER join Discount on discount.reason = ActiveDiscounts.discount where name like " + "'%" + search + "%' or Supplier like " + "'%" + search + "%' or Code like " + "'%" + search + "%' or Price like " + "'%" + search + "%'";
                return dbConnection.selectMultipleRows(cmd);
            }

        }

    }
}
