using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HomeWork2.BL
{
    public class User
    {
        string firstName;
        string familyName;
        string email;
        int password;

        public static List<User> UsersList = new List<User>();

        public User()
        {

        }

        public User(string firstName, string familyName, string email, int password)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Password = password;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Email { get => email; set => email = value; }
        public int Password { get => password; set => password = value; }

        public int InsertUser()
        {
            DBservices dbs = new DBservices();
            return dbs.Insert(this);
        }

        public List<User> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUsers();
        }
        public List<User> ReadLoginUser(string email, int password)
        {
           
             DBservices dbs = new DBservices();
             return dbs.ReadLoginUserByEmailAndPassword(email, password);
        }


    }
}
