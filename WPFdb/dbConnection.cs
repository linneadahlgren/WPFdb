using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdb
{
    public static class dbConnection
    {
        public static int executeQuery(string query)
        {
            int rowCount = 0;
            string connString = @"Server=localhost;Database=OnlineShop;Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = conn;
                sqlCommand.CommandTimeout = 12 * 3600;

                conn.Open();

                rowCount = sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }

            return rowCount;

        }

        public static String[] selectMultipleRows(string cmd)
        {
            string connString = @"Server=localhost;Database=OnlineShop;Trusted_Connection = True;";

            String[] fetchedData = new String[1];

            using (SqlConnection conn = new SqlConnection(connString))
            {

                using (SqlCommand sqlCommand = new SqlCommand(cmd))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {


                        try
                        {
                            int nbrRows = 0;

                            while (sdr.Read())
                            {
                                nbrRows++;
                            }

                                fetchedData = new String[sdr.VisibleFieldCount];
                         
                            for (int i = 0; i < sdr.VisibleFieldCount; i++)
                            {
                                System.Diagnostics.Debug.WriteLine("dbConnection " + sdr[i].ToString());
                                fetchedData[i] = sdr[i].ToString();
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("fel när data hämtades från db ");
                            conn.Close();

                        }


                    }
                    conn.Close();
                }
            }
            return fetchedData;
        }
    

        public static String[] selectQuery(string cmd)
        {
            string connString = @"Server=localhost;Database=OnlineShop;Trusted_Connection = True;";

            String[] fetchedData = new String[1];

            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                using (SqlCommand sqlCommand = new SqlCommand(cmd))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        
                        try
                        {

                            sdr.Read();

                            fetchedData = new String[sdr.VisibleFieldCount];
                            if (sdr.HasRows)
                            {
                                

                            }
                            for (int i = 0; i < sdr.VisibleFieldCount; i++)
                            {
                                System.Diagnostics.Debug.WriteLine("dbConnection " + sdr[i].ToString());
                                fetchedData[i] = sdr[i].ToString();
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("fel när data hämtades från db ");
                            conn.Close();

                        }


                    }
                    conn.Close();
                }
            }
            return fetchedData;
        }
    }
}
