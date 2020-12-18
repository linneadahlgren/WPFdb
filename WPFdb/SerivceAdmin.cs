using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdb
{
    public static class SerivceAdmin
    {

        public static Boolean canAdminLogIn(String userName, String password)
        {
            String cmd = "SELECT Username, Password from Admin where Username= ('" + userName + "')";
            List<String> returnedData = dbConnection.selectFromRowQuery(cmd);
            if(returnedData.Count() == 2)
            {
                if(returnedData.ElementAt(0) == userName && returnedData.ElementAt(1) == password)
                    return true;
            }

            return false;
        }

    }
}
