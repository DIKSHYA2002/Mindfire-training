using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace SQLtesting
{
    internal class Program
    {
        //insert operation
       public  static void InsertCountries()
        {
            using(var dbContext = new Test1Entities())
            {
                Console.WriteLine("Enter the country Name");
                string countryName = Console.ReadLine();
                Console.WriteLine("Enter the country Abr");
                string countryAbr = Console.ReadLine();
               country c = new country;
               
               {
                   CountryName= countryName,
                   CountryAbr= countryAbr
               };
                dbContext.countries.Add(c);
                dbContext.SaveChanges();
                var countriesdata = dbContext.countries;
                foreach (var data in countriesdata)
                {
                    Console.WriteLine(data.CountryID + "\t" + data.CountryName);
                }
            }
        }
        //delete country using id 
       public static void DeleteCountries()
        {
             using(var dbContext = new Test1Entities())
            {
                Console.WriteLine("enter the country id which you want to delete");
                int id = Int32.Parse(Console.ReadLine());
                var itemToRemove = dbContext.countries.SingleOrDefault(x => x.CountryID == id);//returns a single item.
                if (itemToRemove != null)
                {
                    dbContext.countries.Remove(itemToRemove);
                    dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("enter a valid id ");
                }
                var countriesdata = dbContext.countries;
                foreach (var data in countriesdata)
                {
                    Console.WriteLine(data.CountryID + "\t" + data.CountryName);
                }
            }
           
        }

       //display countries 
        public static void DisplayCountries()
        {
            using (var dbContext = new Test1Entities())
            {
                var countriesdata = dbContext.countries;
                foreach (var data in countriesdata)
                {
                    Console.WriteLine(data.CountryID + "\t" + data.CountryName);
                }
            }
        }
        //update countries
        public static void UpdateCountries()
        {

            using (var dbContext = new Test1Entities())
            {
                Console.WriteLine("Enter the country id you want  to update");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter new country Name");
                string countryName = Console.ReadLine();
                country c = (from x in dbContext.countries
                             where x.CountryID == id 
                             select x).First();
                c.CountryName = countryName;
                dbContext.SaveChanges();
            }
        }
        //country state list using procedures 
        public static void CountryStateList()
        {
            using (var dbContext = new Test1Entities())
            {
                /*var innerJoin = from e in dbContext.countries
                                join d in dbContext.States on e.CountryID equals d.CountryID
                                select new
                                {
                                    countryID = e.CountryID,
                                    CountryName = e.CountryName,
                                    StateName = d.StateName
                                };*/
                var innerJoin = dbContext.GetStates();

                Console.WriteLine("Country ID\t Country Name\t State Name");
                foreach (var data in innerJoin)
                {
                    Console.WriteLine(data.CountryID + "\t\t" + data.CountryName + "\t" + data.stateName);
                }
            }

       }
        //display view userdetails
        public static void DisplayView()
        {
            using(var dbContext = new Test1Entities())
            {
                var userview = dbContext.userDetails;
                foreach (var data in userview)
                {
                    Console.WriteLine(data.userName + "\t" + data.userEmail + "\t" + data.CountryName + "\t" + data.StateName);
                }
            }
        }
        static void Main(string[] args)
       {
            CountryStateList();
          /* InsertCountries();
           DeleteCountries();
           DisplayCountries();
           UpdateCountries();
           DisplayCountries();*/
           Console.ReadLine();
        }
    }
}
