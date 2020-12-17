using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdb
{
    public static class ServiceProducts
    {


        public static Boolean addProduct(String productName, String supplier, int quantity, float price)
        {


            String cmd = "insert into Products(Name, Quantity, Price, Supplier) values(('" + productName
              + "'), ('" + quantity+ "'), ('" + price+ "'), ('" + supplier + "'))";  // här ska vi lägga in supplier som en foreing key typ 
            System.Diagnostics.Debug.WriteLine("försökte lägga till " + productName + " till db  rader påverkades ");

            String[] returnedData = dbConnection.selectQuery(cmd);

            return false;
        }
    }
}
