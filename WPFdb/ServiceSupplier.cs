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
            String[] returnedData = dbConnection.selectMultipleRows(cmd);

       
            return returnedData;
        }
    }
}
