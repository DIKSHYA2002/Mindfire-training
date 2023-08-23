using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
   public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryAbr { get; set; }
    }

    public class state
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
    }

    public class Files_Employee
    {
        public int UserId { get; set; }
        public int FileId { get; set; }
        public string ActualFileName { get; set; }
        public DateTime  CreatedOn { get; set; }
        public string StoredFileName { get; set; }
    }
    public class Notes_Employee
    {
        public int ID { get; set; }
        public int Note_ID { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public Nullable<int> To_ID { get; set; }
    }
    public class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    public class Roles_Employee
    {
        public int userID { get; set; }
        public int RoleID { get; set; }
    }

    public class Employee
    {
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int UserPresentCountryID { get; set; }
        public int UserPresentStateID { get; set; }
        public string UserGender { get; set; }
        public System.DateTime UserDateOfBirth { get; set; }
        public string UserPresentLine1 { get; set; }
        public string UserPresentLine2 { get; set; }
        public int UserPresentPincode { get; set; }
        public int UserPermanentPincode { get; set; }
        public string UserPermanentLine1 { get; set; }
        public string UserPermanentLine2 { get; set; }
        public string UserPresentCity { get; set; }
        public string UserPermanentCity { get; set; }
        public string UserHobbies { get; set; }
        public string UserSubscribed { get; set; }
        public int UserPermanentCountryID { get; set; }
        public int UserPermanentStateID { get; set; }
        public string Imagename { get; set; }
        public string Userpassword { get; set; }
    }
}
