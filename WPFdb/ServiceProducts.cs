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
            if (supplier == "")
                return false; 

            String cmd = "insert into Products(Name, Quantity, Price, Supplier) values(('" + productName
              + "'), ('" + quantity+ "'), ('" + price+ "'), ('" + supplier + "'))";  // här ska vi lägga in supplier som en foreing key typ 

            
            System.Diagnostics.Debug.WriteLine("försökte lägga till " + productName + " till db  rader påverkades ");

            if(dbConnection.insertQuery(cmd) == 1)
                return true;
       

            return false;
        }

        public static List<String[]> getAllProductsToDisplay()
        {

            return null;

        }
    }
}
