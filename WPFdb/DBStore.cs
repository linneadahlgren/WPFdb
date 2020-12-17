using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WPFdb
{
    class DBStore
    {

        public DBStore()
        {
            string connString = @"Server=localhost;Database=OnlineStore;Trusted_Connection = True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

        }

    }
}
