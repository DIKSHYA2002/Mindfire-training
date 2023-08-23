using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeMangaement.DAL;
using EmployeeManagement.Models;
namespace EmpployeeManagement.Business
{
    public class CountryStateBusiness
    {
        public static  String GetCountryName(int id)
        {
            String CountryName = AccessCountryState.GetCountries().Where(country=> country.Equals(id)).First().CountryName;
           return CountryName;
        }
        public static String GetStateName(int id)
        {
            String StateName = AccessCountryState.GetStates().Where(state => state.Equals(id)).First().StateName;
            return StateName;
        }
        public static List<Country> GetCountryList()
        {
            List<Country> countryList = AccessCountryState.GetCountries().Select(st => new Country
            {
                CountryId = st.CountryID,
                CountryName = st.CountryName,
                CountryAbr = st.CountryAbr
            }).ToList();

            return countryList;
        }
        public static List<state> GetStateList(int countryid)
        {
            List<state> statelist = AccessCountryState.GetStatesFromCountryId(countryid).Where(state=>state.CountryID== countryid).Select(st => new state
            {
                StateId = st.StateID,
                StateName = st.StateName,
                CountryID = st.CountryID ,
            }).ToList();
            return statelist;
        }


      
    }
   
}
