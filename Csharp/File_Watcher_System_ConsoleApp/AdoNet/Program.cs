using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdoNet
{
   
    class Program
    {
        static int userID;
        static String FirstName;
        static String LastName;
        static String Email;
        static String ConnectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=profileapplication";
        public static void SelectPersonalData()
        {
            DataTable ds = new DataTable();
            using (var con = new MySqlConnection(ConnectionString))
            {
                var sde = new MySqlDataAdapter("Select * from personaldata", con);
                sde.Fill(ds);
                foreach (DataRow row in ds.Rows)
                {
                    Console.WriteLine(row["userID"] + ",  " + row["FirstName"] + ",  " + row["LastName"] + ", " + row["Email"]);
                }
                Console.ReadLine();
            }
        }
        public static void AddPersonalData()
        {
            DataTable ds = new DataTable();
            using (var con = new MySqlConnection(ConnectionString))
            {
                string FirstName = Console.ReadLine();
                string LastName = Console.ReadLine();
                string Email = Console.ReadLine();
                var sde = new MySqlDataAdapter($"INSERT INTO personaldata ( FirstName,LastName,Email) VALUES ('{FirstName}' ,'{LastName}','{Email}' )", con);
                sde.Fill(ds);
                Console.WriteLine("inserted one row succesfully ");
            }
        }
        public static void Update(string attributeName , string value) {
            DataTable ds = new DataTable();
            using (var con = new MySqlConnection(ConnectionString))
            {
                var sde = new MySqlDataAdapter($"UPDATE personaldata SET {attributeName}='{value}' WHERE userID ={userID} ", con);
                sde.Fill(ds);
                Console.WriteLine("altered one row succesfully");
            }
        }


        public static void UpdatePersonalData()
        {
            DataTable ds = new DataTable();
            bool counter = true;
            while (counter)
            {
                Console.WriteLine("Enter the ID :");
                userID = Int32.Parse(Console.ReadLine());
                using (var con = new MySqlConnection(ConnectionString))
                {
                    var sde = new MySqlDataAdapter($"Select * from personaldata where userID='{userID}'", con);
                    sde.Fill(ds);
                    foreach (DataRow row in ds.Rows)
                    {
                        FirstName = row["FirstName"].ToString();
                        LastName = row["LastName"].ToString();
                        Email = row["email"].ToString();
                        Console.WriteLine( row["FirstName"] + ",  " + row["LastName"] + ", " + row["Email"]);
                    }
                    Console.WriteLine("Enter your choice \n 1-Change FirstName\n 2- Change LastName\n 3-Change Email \n 4-Nothing");
                    int choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            FirstName = Console.ReadLine();
                            Update("FirstName", FirstName);
                            break;
                        case 2:
                            LastName = Console.ReadLine();
                            Update("LastName", LastName);
                            break;
                        case 3:
                            Email = Console.ReadLine();
                            Update("Email", Email);
                            break;
                        default:
                            counter = false;
                            break;
                    }
                   
                }
               
            }
        }
        static void Main(string[] args)
        {
            bool counter = true;
            while(counter)
            {
                Console.WriteLine("Enter your choice \n 1-Display Personal Data\n 2- ADD USER \n 3-UPDATE USER \n 4-EXIT");
                int choice = Int32.Parse( Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SelectPersonalData();
                        break;
                    case 2:
                        AddPersonalData();
                        break;
                    case 3:
                        UpdatePersonalData();
                        break;
                    default:
                        counter = false;
                        break;
                }
            }
        }
    }
}
