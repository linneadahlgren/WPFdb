using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdb
{
    public static class ServiceDiscount 
    {
        public static Boolean createDiscount(String name,int discount)
        {
            String cmd = "Insert into Discount (Precentage,Reason) values (('" + discount + "'),('" + name + "'))";
            if (dbConnection.insertQuery(cmd) == 1)
                return true;
            
            return false;
        }
    }
}
