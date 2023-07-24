using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdoNet
{
    class Class1
    {
        public void DisplayRecordNone(MySqlConnection con)
        {
            using (con)
            {
                con.Open();
                MySqlCommand cm = new MySqlCommand("select * from country", con);
                MySqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["countryID"] + ",  " + sdr["countryName"]);
                }
                con.Close();
            }
            
        }
        public void DisplayRecord(MySqlConnection con)
        {
            try
            {
                using (con)
                {
                    MySqlCommand cm = new MySqlCommand("get_Countries", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    con.Open();
                    MySqlDataReader sdr = cm.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["countryID"] + ",  " + sdr["countryName"]);
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("exception" +ex);
            }
           
        }
        static void Main(string[] args)
        {
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mindfire;database=profileapplication");
            new Class1().DisplayRecordNone(con);
           // new Class1().Update(con);
            Console.ReadKey();
        }
        public void Update(MySqlConnection con)
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from country", con);
            dataAdapter.UpdateCommand = new MySqlCommand(
           "UPDATE country SET countryName = @CountryName " +
           "WHERE countryID = @countryID", con);
            dataAdapter.UpdateCommand.Parameters.Add("@CountryName", MySqlDbType.VarChar, 45, "countryName");
            MySqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add(
              "@countryID", MySqlDbType.UInt32);
            parameter.SourceColumn = "countryID";
            parameter.SourceVersion = DataRowVersion.Original;
            DataTable countryTable = new DataTable();
            dataAdapter.Fill(countryTable);
            DataRow crow = countryTable.Rows[0];
            crow["countryName"] = "India";
            dataAdapter.Update(countryTable);
            Console.WriteLine("Rows after update.");
            foreach (DataRow row in countryTable.Rows)
            {
                {
                   Console.WriteLine("{0}: {1}", row[0], row[1]);
                }
            }

        }

        public void InsertRecord(MySqlConnection con)
        {
            using(con)
            {
                MySqlCommand cm = new MySqlCommand("insert into country (CountryName,CountryAbr) values ( 'country_5','c5')", con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully");

            }
          
        }
    }
}
