using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WPFdb
{
    public static class ServiceDiscount
    {
        public static Boolean createDiscount(String name, int discount)
        {
            String cmd = "Insert into Discount (Precentage,Reason) values (('" + discount + "'),('" + name + "'))";
            if (dbConnection.insertQuery(cmd) == 1)
                return true;

            return false;
        }
        public static String[] getallDiscountNames()
        {
            String cmd = "Select Reason from Discount";

            List<String[]> returnedData = dbConnection.selectMultipleRows(cmd);
            String[] discountList = new String[returnedData.Count];
            for (int i = 0; i < returnedData.Count; i++)
            {
                discountList[i] = returnedData.ElementAt(i)[0];
            }
            return discountList;
        }
        public static Boolean discountProduct(String produkt, String discount, String start_date, String end_date)
        {
            int produktCode = ServiceProducts.getProduktCodeFromName(produkt);
            String cmd = "Insert into activeDiscounts (ProductCode,Discount,start_date,end_date) values (('" + produktCode+"'), ('" + discount + "'),('" + start_date + "'),('" + end_date + "'))";
            if (dbConnection.insertQuery(cmd) == 1)
                return true;

                return false;

        }
        public static List<String[]> getAllDiscounts()
        {
            String cmd = "SELECT P.name,Discount, Start_date,End_date,P.price,Discount.Precentage,(Price-(Price*(0.01*Precentage))) from Products as P JOIN ActiveDiscounts on p.code = ActiveDiscounts.productCode join Discount on discount.reason = ActiveDiscounts.discount";

            return dbConnection.selectMultipleRows(cmd);
        }

        public static DataTable getAllDiscountHistoryToDisplay()
        {
            List<String[]> list = getAllDiscounts();
            DataTable table = new DataTable();
            String[] column = new String[] { "Product Name","Discount", "Start date", "End date", "Price", "Precentage", "Discount Price" };

            foreach (var col in column)
                table.Columns.Add(col);

            foreach (var array in list)
                table.Rows.Add(array);

            return table;
        }

    }
}
