using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdb
{
    public static class ServiceCustomer
    {
        public static Boolean isUserCredentialsCorrect(String email, String password)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("vi skickar til db från service " + email);

                String cmd = "SELECT Email, Password from Customer where Email = ('" + email + "')";
                List<String> returnedData = dbConnection.selectFromRowQuery(cmd);
                if(email == returnedData.ElementAt(0) && password == returnedData.ElementAt(1))
                    return true;
                else
                    return false;

            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public static String getNameFromEmail(String email)
        {
            String cmd = "SELECT FirstName from Customer where Email = ('" + email + "')";
            List<String> returnedData = dbConnection.selectFromRowQuery(cmd);
            if(returnedData.ElementAt(0) != null)
            {
                return returnedData[0];
            }
            return "";
        }

        public static Boolean registerNewUser(String email, String password, String firstName, String lastname, String address, String city, String country, int phonenumber)
        {
            if (isEmailAvailable(email))
            {
                int length = dbConnection.insertQuery("insert into Customer(Email, Password, FirstName, LastName, Address, City, Country, PhoneNumber) values(('" + email
              + "'), ('" + password + "'), ('" + firstName+ "'), ('" +lastname+ "'), ('" + address+ "'), '', ('" + city+ "'), ('" + phonenumber + "'))");
                System.Diagnostics.Debug.WriteLine("försökte lägga till " + email + " till db " + length + " rader påverkades ");
                if (length == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private static Boolean isEmailAvailable(String email)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("vi skickar til db från service " + email);

                String cmd = "SELECT Email from Customer where Email = ('" + email + "')";
                List<String> returnedData = dbConnection.selectFromRowQuery(cmd);
                if (email == returnedData.ElementAt(0))
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
