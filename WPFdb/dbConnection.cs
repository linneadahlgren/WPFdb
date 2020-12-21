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
        public static string connString =  @"Server=localhost;Database=OnlineShop;Trusted_Connection = True;";

        public static int insertQuery(string query)
        {
            int rowCount = 0;
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


        public static List<String[]> selectMultipleRows(string cmd)
        {
            List<String[]> fetchedData = new List<String[]>();

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
                            while (sdr.Read())
                            {
      
                                String[] tempList = new string[sdr.VisibleFieldCount];                                
                                for (int i = 0; i < sdr.VisibleFieldCount; i++)
                                {
                                    Console.WriteLine(sdr[i].ToString());
                                    tempList[i] = sdr[i].ToString();
                                }
                                fetchedData.Add(tempList);
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("fel när flera rader hämtades från db ");
                            conn.Close();

                        }
                    }
                    conn.Close();
                }
            }
            return fetchedData;
        }
    

        public static List<String> selectFromRowQuery(string cmd)
        {
            List<String> fetchedData = new List<string>();

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
                           
                            for (int i = 0; i < sdr.VisibleFieldCount; i++)
                            {
                                System.Diagnostics.Debug.WriteLine("dbConnection " + sdr[i].ToString());
                                fetchedData.Add(sdr[i].ToString());
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
