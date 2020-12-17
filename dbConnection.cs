using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Class1
{
    public static int executeQuery(string query)
    {
        int rowCount = 0;
        string connString = @"Server=localhost;Database=OnlineShop;Trusted_Connection = True;";
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand sqlCommand = new SqlCommand();

        try
        {
            sqlCommand.CommandText = "query";
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Connection = conn;
            sqlCommand.CommandTimeout = 12 * 3600;

            conn.Open();

            rowCount = sqlCommand.ExectureNonQuery();

            conn.Close();
        }
        catch (Exception ex)
        {
            conn.Close();
            throw ex;
        }

        return rowCount;

    }
}
