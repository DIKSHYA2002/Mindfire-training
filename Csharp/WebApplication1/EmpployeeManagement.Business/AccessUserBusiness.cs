using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeMangaement.DAL;
using EmployeeManagement.Models;

namespace EmpployeeManagement.Business
{
    public class AccessUserBusiness
    {
        public static List<Employee> GetUsers()
        {
            List<Employee> userlist = DatabaseUsers.GetUsers().Select(st => new Employee
            {
                UserID = st.userID,
                UserEmail = st.userEmail,
                UserDateOfBirth = st.userDateOfBirth,
                UserFirstName = st.userFirstName,
                UserLastName = st.userLastName,
                UserGender = st.userGender,
                Userpassword = st.userpassword,
                UserPhone = st.userPhone,
                UserHobbies = st.userHobbies,
                UserSubscribed = st.userSubscribed,
                UserPresentLine1 = st.userPresentLine1,
                UserPresentCountryID = st.userPresentCountryID,
                UserPresentLine2 = st.userPresentLine2,
                UserPresentPincode = st.userPresentPincode,
                UserPresentStateID = st.userPresentStateID,
                Imagename = st.imagename,
                UserPresentCity = st.imagename,
                UserPermanentLine1 = st.userPermanentLine1,
                UserPermanentLine2 = st.userPermanentLine2,
                UserPermanentCity = st.userPermanentCity,
                UserPermanentCountryID = st.userPermanentCountryID,
                UserPermanentPincode = st.userPermanentPincode,
                UserPermanentStateID = st.userPermanentStateID,
            }).ToList();
            return userlist;
        }

        public static Employee GetUser(int id)
        {
            Employee employee = GetUsers().Where(user=>user.UserID==id).FirstOrDefault();
            return employee;
        }

        public static List<Roles> GetAllRoles()
        {
            List<Roles> roles = DatabaseUsers.GetAllRoles().Select(st => new Roles
            {
                RoleID = st.RoleID,
                RoleName = st.RoleName,
            }).ToList();
            return roles;
        }
        public static List<Roles_Employee> GetUserRoles(int id)
        {
            List<Roles_Employee> roles = DatabaseUsers.GetUserRoles(id).Select(st => new Roles_Employee
            {
                RoleID = st.RoleID,
                userID = st.userID,
            }).ToList();
            return roles;
        }

        public static void SubmitUserRoles(int[] arr ,int userid)
        {
            DatabaseUsers.SubmitUserRoles(arr , userid);
            
        }

        public static void EditUserRoles(int[] arr, int userid)
        {
            DatabaseUsers.EditUserRoles(arr, userid);

        }

        public static String GetUserRoleString(int id)
        {
            String role = String.Empty;
            List<Roles> roles = GetAllRoles();
            GetUserRoles(id).ForEach(users =>
            {
                role += String.Join(",", roles.Select(s => s.RoleID == users.RoleID).Single());
            });
            return role;
        }

        public static List<Files_Employee> GetFiles_Employees()
        {
            List<Files_Employee> files = DatabaseUsers.GetAllFiles().Select(s => new Files_Employee
            {
                UserId = s.userid,
                FileId = s.fileid,
                ActualFileName = s.ActualfileName,
                StoredFileName = s.StoredFileName,
                CreatedOn = s.CreatedOn
            }).ToList();
            return files;
        }
        public static List<Files_Employee> GetFiles_Employees(int id)
        {
            List<Files_Employee> files = DatabaseUsers.GetAllFiles().Where(s=>s.userid== id).Select(s => new Files_Employee
            {
                UserId = s.userid,
                FileId = s.fileid,
                ActualFileName = s.ActualfileName,
                StoredFileName = s.StoredFileName,
                CreatedOn = s.CreatedOn
            }).ToList();
            return files;
        }

        public static List<Notes_Employee> GetNotes_Employees(int id)
        {
            List<Notes_Employee> notes = DatabaseUsers.GetAllNotes().Where(s=>s.Note_ID == id && s.Type =="User" || ( s.To_ID == id && s.Type == "User")).Select(s => new Notes_Employee
            {
                Note_ID = s.Note_ID,
                Note = s.Note,
                ID = s.ID,
                To_ID = s.To_ID,
            }).ToList();
            return notes;
        }


        public static List<Notes_Employee> GetNotes_Private(int id)
        {

            List<Notes_Employee> notes = DatabaseUsers.GetAllNotes().Where(s => s.To_ID == id && s.Type=="Company").Select(s => new Notes_Employee
            {
                Note_ID = s.Note_ID,
                Note = s.Note,
                ID = s.ID,
                To_ID = s.To_ID,
            }).ToList();
            return notes;
        }





        public static void SubmitFiles(Files_Employee fs)

        {
            DatabaseUsers.SubmitFile(fs);

        }

        public static bool IsAdmin(int id)
        {
            return DatabaseUsers.IsAdmin(id);
        }
        public static int IsUser(String email , String password)
        {
            return DatabaseUsers.IsUser(email, password);
        }

        public static void SetNotes(Notes_Employee notes)
        {
            try
            {
                DatabaseUsers.SetNotes(notes);
               
            }
            catch (Exception )
            {
                

            }
        }
        public static int SubmitUser(Employee e)
        {
            try
            {
               return  DatabaseUsers.SubmitUser(e);
               
            }
            catch(Exception)
            {
                return -1;
            }

        }
        public static bool DeleteUser(int userId)
        {
            return DatabaseUsers.DeleteUser(userId);
        }
        public static bool EditUser(Employee e)
        {
            try
            {
                DatabaseUsers.EditUser(e);
                return true;
            }
            catch(Exception )
            {
                return false;
            }
           
        }

        public static bool DeleteNote(int noteId)
        {
            return DatabaseUsers.DeleteNote(noteId);
        }
        public static string DeleteFile(int fileId)
        {
            return DatabaseUsers.DeleteFile(fileId);

        }
        
    }
}

