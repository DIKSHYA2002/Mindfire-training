using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMangaement.DAL;
using EmployeeManagement.Models;
using EmployeeManagement.Utils;
using System.Data.Entity;
using System.Xml.Linq;

namespace EmployeeMangaement.DAL
{
    public class DatabaseUsers 
    {

        public static void SubmitUserRoles(int[] arr , int userid)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {
                    for(int i=0  ; i<arr.Length; i++)
                    {
                        UserRole u = new UserRole();
                        u.userID = userid;
                        u.RoleID = arr[i];
                        dtContext.UserRoles.Add(u);
                    }
                    dtContext.SaveChanges();
                 
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
               
            }

        }

        public static void DeleteUserRoles(int userid)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {
                    var User = dtContext.UserRoles.Where(i => i.userID == userid).ToList();
                    dtContext.UserRoles.RemoveRange(User);
                    dtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
           
        }


        public static void EditUserRoles(int[] arr, int userid)
        {
            try
            {
              
                    DeleteUserRoles(userid);
                   SubmitUserRoles(arr, userid);
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }

        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try{
                using (var entities = new Test1Entities1())
                {
                   users= entities.Users.ToList();
                }
             
                return users;

            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
              
            }
            return null;

        }
        public static User GetUser(int id)
        {
            User u = new User();
            try
            {
                using (var entities = new Test1Entities1())
                {
                    u = entities.Users.Where(us => us.userID == id).FirstOrDefault();
                    return u;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
               
            }
            return null;

        }
        public static  List<Role> GetAllRoles()
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<Role> roles = entities.Roles.ToList();
            
                    return roles;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return null;
        }
        public static List<Note_Text> GetAllNotes()
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<Note_Text> Note_Texts = entities.Note_Text.ToList();
                    return Note_Texts;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;

        }
        public static List<Files_Storage> GetAllFiles()
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<Files_Storage> Files_Storages = entities.Files_Storage.ToList();
                    return Files_Storages;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;

        }
        public static List<UserRole> GetUserRoles(int id)
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<UserRole> UserRoles = entities.UserRoles.Where(roles => roles.userID == id).ToList();
                    return UserRoles;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;
        }
        public static List<UserRole> GetUserRoles()
        {
            try
            {
                using (var entities = new Test1Entities1())
                {
                    List<UserRole> UserRoles = entities.UserRoles.ToList();
                    return UserRoles;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);

            }
            return null;


        }


        public static void SetNotes(Notes_Employee note)
        {

            try
            {
                using(var dtcontext = new Test1Entities1())
                {
                    Note_Text notes = new Note_Text();
                    notes.Note_ID = note.Note_ID;
                    notes.To_ID = note.To_ID;
                    notes.Type = note.Type;
                    notes.Note = note.Note;
                    dtcontext.Note_Text.Add(notes);
                    dtcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }

        }
        public static int IsUser(String email , String password)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {
                    if((email != "") && password != "") 
                    {
                        var user = dtContext.Users.Single(x => x.userEmail == email);
                        var userroles = dtContext.UserRoles.Where(x => x.userID == user.userID).ToList();
                        if (user.userpassword == password)
                        {
                            return user.userID;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    } 
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return -1;
        }

        public static bool IsAdmin(int id)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {

                    var user = dtContext.Users.Single(x => x.userID == id);
                    var userroles = dtContext.UserRoles.Where(x => x.userID == user.userID).ToList();
                    var isadmin = false;
                    foreach (var x in userroles)
                    {
                        if (x.RoleID == 7)
                        {
                            isadmin = true;
                        }
                    }
                    return isadmin;
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return false;
          
          
        }


        public static bool DeleteUser(int userId)
        {
            try
            {
                using(var dtContext = new Test1Entities1())
                {
                    var User = dtContext.Users.FirstOrDefault(i => i.userID == userId);
                    dtContext.Users.Remove(User);
                    dtContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return false;

        }

        public static int SubmitUser(Employee user)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {
                    User u = new User();
                    u.userFirstName = user.UserFirstName;
                    u.userLastName = user.UserLastName;
                    u.userEmail = user.UserEmail;
                    u.userPhone = user.UserPhone;
                    u.userGender = user.UserGender;
                    u.userpassword = user.Userpassword;
                    u.userHobbies = user.UserHobbies;
                    u.userPresentLine1 = user.UserPresentLine1;
                    u.userPresentLine2 = user.UserPresentLine2;
                    u.userPresentPincode = user.UserPresentPincode;
                    u.userDateOfBirth = user.UserDateOfBirth;
                    u.userPresentCountryID = user.UserPresentCountryID;
                    u.userPresentStateID = user.UserPresentStateID;
                    u.userPermanentLine1 = user.UserPermanentLine1;
                    u.userPermanentLine2 = user.UserPermanentLine2;
                    u.userPermanentCountryID = user.UserPermanentCountryID;
                    u.userPermanentStateID = user.UserPermanentStateID;
                    u.userPermanentPincode = user.UserPermanentPincode;
               
                    u.imagename = user.Imagename;
                    u.userSubscribed = user.UserSubscribed;
                    u.userPermanentCity = user.UserPermanentCity;
                    u.userPresentCity = user.UserPresentCity;
                    dtContext.Users.Add(u);
                    dtContext.SaveChanges();
                    return u.userID;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
                return -1;
            }
           
        }
          
        
        public static void SubmitFile(Files_Employee fs)
        {
            try
            {
                using (var dtcontext = new Test1Entities1())
                {
                    Files_Storage file = new Files_Storage();
                    file.userid = fs.UserId;
                    file.StoredFileName = fs.StoredFileName;
                    file.CreatedOn = fs.CreatedOn;
                    file.ActualfileName = fs.ActualFileName;
                    dtcontext.Files_Storage.Add(file);
                    dtcontext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
          
        }

        public static void EditUser(Employee user)
        {
            using (Test1Entities1 entities = new Test1Entities1())
            {
                User u  = (from c in entities.Users
                            where c.userID == user.UserID
                            select c).FirstOrDefault();
                u.userFirstName = user.UserFirstName;
                u.userLastName = user.UserLastName;
                u.userEmail = user.UserEmail;
                u.userPhone = user.UserPhone;
                u.userGender = user.UserGender;
                u.userpassword = user.Userpassword;
                u.userHobbies = user.UserHobbies;
                u.userPresentLine1 = user.UserPresentLine1;
                u.userPresentLine2 = user.UserPresentLine2;
                u.userPresentPincode = user.UserPresentPincode;
                u.userDateOfBirth = user.UserDateOfBirth;
                u.userPresentCountryID = user.UserPresentCountryID;
                u.userPresentStateID = user.UserPresentStateID;
                u.userPermanentLine1 = user.UserPermanentLine1;
                u.userPermanentLine2 = user.UserPermanentLine2;
                u.userPermanentCountryID = user.UserPermanentCountryID;
                u.userPermanentStateID = user.UserPermanentStateID;
                u.userPermanentPincode = user.UserPermanentPincode;
                if(user.Imagename!="")
                {
                    u.imagename = user.Imagename;
                }
                u.userSubscribed = user.UserSubscribed;
                u.userPermanentCity = user.UserPermanentCity;
                u.userPresentCity = user.UserPresentCity;
                entities.SaveChanges();
            }
        }


        public static bool DeleteNote(int noteId)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {
                    var notes = dtContext.Note_Text.FirstOrDefault(i => i.ID == noteId);
                    dtContext.Note_Text.Remove(notes);
                    dtContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return false;

        }

        public static string DeleteFile(int fileId)
        {
            try
            {
                using (var dtContext = new Test1Entities1())
                {
                    var files = dtContext.Files_Storage.FirstOrDefault(i => i.fileid == fileId);
                    var filename = files.StoredFileName;
                    dtContext.Files_Storage.Remove(files);
                    dtContext.SaveChanges();

                    return filename;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
            return String.Empty;

        }



    }
}
