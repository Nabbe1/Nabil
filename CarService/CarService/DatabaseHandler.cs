using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CarService
{
    public class DatabaseHandler
    {

        // Uppdaterar den redan som jag själv väljer genom att peka på ID:et i Sql som i mitt fall är Counter
        public static void UpdateRow(string Make, string Year, string CarID, int Counter)
        {
            string strQuery = "update Cars set Make = '" + Make + "', CarID='" + CarID + "', YearOfModel = '" + Year + "' where counter = " + Counter;
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
       
        // Skapar en ny rad i Databasen
        public static void CreateRow(string Make, string Year, string CarID)
        {
            string strQuery = ("INSERT INTO Cars(CarID, Make, YearOfModel) values ('" + CarID + "', '" + Make + "', '" + Year + "')");
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
           
        }

        // Tar bort den radan från Databasen som jag väljer att peka på genom att använda Counter som i ID i Sql
        public static void DeleteRow(string Make, string Year, string CarID, int Counter)
        {
            string strQuery = ("DELETE FROM Cars WHERE counter = " + Counter);
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Listar den redan jag väljer att visa genom att använda Counter som är ID i Sql
        public static string[] ListRow(int Counter)
        {
            string[] s = new string[3];
            string strQuery = "Select Make, CarID, YearOfModel FROM Cars where counter = " + Counter;
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {


                s[0] = r["Make"].ToString();
                s[1] = r["YearOfModel"].ToString();
                s[2] = r["CarID"].ToString();
                // ...

            }
            conn.Close();
            return s;
        }

        // Listar alla CarID vilket är Regnummer i mitt fall
        public static string[] ListAllId()
        {
            //string[] s = new string[1];
            ArrayList al = new ArrayList();

            string strQuery = "Select CarID from Cars";// where counter = " + Counter;
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                al.Add(r["CarID"].ToString());
            }
            conn.Close();
            return GetStringArray(al);
       }

        // Funktion för att konvertera Obejekten i min ArrayList till string format
        public static string[] GetStringArray(ArrayList al)
        {
            string[] returnarr = new string[al.Capacity]; 
            for (int i = 0; i < al.Capacity; i++)
            {
                returnarr[i] = al[i].ToString();
            }
            return returnarr;
        }
        //public static List<object> GetAll()
        //{
        //    List<object> rows = new List<object>();

        //    var Query = "Select Counter, Make, CarID, YearOfModel FROM Cars";//.AsEnumerable();
        //    SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
        //    SqlCommand cmd = new SqlCommand(Query, conn);
        //    conn.Open();
        //    var r = cmd.ExecuteReader();

        //    while (r.Read())
        //    {
        //        string[] cols = new string[3];
        //        cols[0] = r["Make"].ToString();
        //        cols[1] = r["YearOfModel"].ToString();
        //        cols[2] = r["CarID"].ToString();
        //        rows.Add(cols);
        //    }
        //    r.Close();
        //    conn.Close();
        //    return rows;
        //}


        // Hämtar all Information från Sql databasen Cars
        public static string[][] RetriveAllInfoFromDb()
        {
            ArrayList y = new ArrayList();
            string[] x;

            string strQuery = "Select Counter, Make, CarID, YearOfModel FROM Cars";
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Car;Data Source=DESKTOP-8VHJKDS\SPO17DBTEK1;");
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                x = new string[4];
                x[0] = r["Counter"].ToString();
                x[1] = r["Make"].ToString();
                x[2] = r["YearOfModel"].ToString();
                x[3] = r["CarID"].ToString();
                //x.Add(r["Counter"].ToString());
                //x.Add(r["Make"].ToString());
                //x.Add(r["CarID"].ToString());
                //x.Add(r["YearOfModel"].ToString());

                y.Add(x);
            }
            conn.Close();
            return GetNewStringArray(y);
        }

        // Funktion för att konvertera Objekten i min ArrayList till string format
        public static string[][] GetNewStringArray(ArrayList y)
        {
            int i = 0;
            string[][] returnarr = new string[y.Count][];
            foreach (string[] x in y)
            {
               returnarr[i++] = x;
            }
            return returnarr;
        }

    }
}


    