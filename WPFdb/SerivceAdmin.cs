﻿using System;
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
            String[] returnedData = dbConnection.selectQuery(cmd);
            if(returnedData.Length == 2)
            {
                if(returnedData[0] == userName && returnedData[1] == password)
                    return true;
            }

            return false;
        }

    }
}
