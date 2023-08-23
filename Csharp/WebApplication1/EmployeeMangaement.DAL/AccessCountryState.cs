using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Utils;

namespace EmployeeMangaement.DAL
{
    public class AccessCountryState
    {
        public static List<country> GetCountries()
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<country> countryList = entities.countries.ToList();
                    return countryList;
                }
            }
           
             catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return null;
            }
        }

        public static List<State> GetStates()
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<State> statelist = entities.States.ToList();
                    return statelist;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return null;
            }
           
        }
        public static List<State> GetStatesFromCountryId(int id)
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<State> statelist = entities.States.Where(states => states.CountryID == id).ToList();
                    return statelist;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return null;
            }
           
        }
    }
}
