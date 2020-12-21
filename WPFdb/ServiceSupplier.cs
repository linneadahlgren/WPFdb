using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdb
{
    public static class ServiceSupplier
    {

        public static String[] getAllSuppliers()
        {
            String cmd = "SELECT Name FROM supplier";

            List<String[]> returnedData = dbConnection.selectMultipleRows(cmd);
            String[] supplierList = new String[returnedData.Count];
            for(int i = 0; i < returnedData.Count; i++)
            {
                supplierList[i] = returnedData.ElementAt(i)[0];
            }
       
            return supplierList;
        }

        public static Boolean addSupplier(String name, int phonenumber, String address)
        {
            String cmd = "INSERT into Supplier (name, phonenumber, address) values (('" + name + "'), ('" + phonenumber + "'), ('" + address + "'))";
            int successful = dbConnection.insertQuery(cmd);

            if (successful == 1)
                return true;

            return false;
        }
    }
}
