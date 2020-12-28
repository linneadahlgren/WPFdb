using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;

namespace WPFdb
{
    public static class ServiceProducts
    {


        public static Boolean addProduct(String productName, String supplier, int quantity, float price)
        {
            if (supplier == "")
                return false; 

            String cmd = "insert into Products(Name, Quantity, Price, Supplier) values(('" + productName
              + "'), ('" + quantity+ "'), ('" + price+ "'), ('" + supplier + "'))";  // här ska vi lägga in supplier som en foreing key typ 

            
            System.Diagnostics.Debug.WriteLine("försökte lägga till " + productName + " till db  rader påverkades ");

            if(dbConnection.insertQuery(cmd) == 1)
                return true;
       

            return false;
        }


        public static List<String[]> getAllProducts()
        {
            String cmd = "SELECT code, name, price, supplier from Products";

            return dbConnection.selectMultipleRows(cmd);

        }
        public static DataTable getProductsToDisplay()
        {
            List<String[]> list = getAllProducts();
            Console.WriteLine(" hallå " + list.Count);
            DataTable table = new DataTable();
            String[] columnHeader = new String[] { "Code", "Product", "Price", "Supplier", "Discount"};


            foreach ( var col in columnHeader) 
                table.Columns.Add(col);

            foreach (var array in list)
                table.Rows.Add(array);

            DataColumn cbBuy = new DataColumn("Buy", typeof(Boolean));
            cbBuy.DefaultValue = false;
            DataColumn qtn = new DataColumn("Qty", typeof(String));
            qtn.DefaultValue = "0";

            table.Columns.Add(cbBuy);
            table.Columns.Add(qtn);

            return table;

        }

        public static int getAvailableProductQuantity(int productCode)
        {
            String cmd = "SELECT quantity from Products where code = ('" + productCode + "') ";

            List<String> data = dbConnection.selectFromRowQuery(cmd);

            return int.Parse(data.ElementAt(0));
        }

        public static DataTable getShoppingListFromSelectedProducts(DataTable table)
        {
           // DataTable table = allProducts;
            List<int> indexToDelete = new List<int>();
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row[1] + " " + row["Buy"] + " index " + i.ToString());
                if (row["Buy"].ToString() == "False")
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
        public static String[] getAllProductsName()
        {

            String cmd = "SELECT Name from Products";


            List<String[]> returnedData = dbConnection.selectMultipleRows(cmd);
            String[] productList = new String[returnedData.Count];
            for (int i = 0; i < returnedData.Count; i++)
            {
                productList[i] = returnedData.ElementAt(i)[0];
            }
            return productList;

        }
        public static int getProduktCodeFromName(String name)
       {
            String cmd = "Select Code from Products where Name = ('" + name + "')";
            //return int.Parse(dbConnection.selectFromRowQuery(cmd).ElementAt(0));
            List<String[]> returnedData = dbConnection.selectMultipleRows(cmd);
            return int.Parse(returnedData.ElementAt(0)[0]);
        } 




    }
}
