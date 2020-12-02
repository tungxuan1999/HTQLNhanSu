using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HTQLNhanSu.DAL
{
    public class LoginDAOSQL
    {
        static String strCon = "Data Source=den1.mssql8.gear.host;Persist Security Info=True;User ID=employeeat;Password=Cy5PUI-v9-4j";
        private DataLoginDataContext db = new DataLoginDataContext(strCon);
        public List<Accounts> SelectALL()
        {
            db.ObjectTrackingEnabled = false;
            List<Accounts> accounts;
            accounts = (from p in db.user_logins
                        select new Accounts
                        {
                            ID = p.ID,
                            USERNAME = p.username,
                            PERMISSTION = p.permission
                        }).ToList();
            return accounts;
        }

        public bool InsertAccount(user_login login)
        {
            try
            {
                login.password = CreateMD5(login.password);
                db.user_logins.InsertOnSubmit(login);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAccount(user_login login)
        {
            try
            {
                user_login data = db.user_logins.SingleOrDefault(Login => Login.ID == login.ID);
                if (data != null)
                {
                    data.ID = login.ID;
                    data.username = login.username;
                    data.password = CreateMD5(login.password);
                    data.permission = login.permission;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount(user_login login)
        {
            try
            {
                user_login animal = db.user_logins.Single(u => u.ID == login.ID);
                db.user_logins.DeleteOnSubmit(animal);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Accounts> SelectByName(String keyword)
        {
            db.ObjectTrackingEnabled = false;
            List<Accounts> animals;

            animals = (from p in db.user_logins
                       where p.username.Contains(keyword)
                       select new Accounts
                       {
                           ID = p.ID,
                           USERNAME = p.username,
                           PERMISSTION = p.permission
                       }).ToList();
            return animals;

        }

        public Accounts SelectByID(String id)
        {
            db.ObjectTrackingEnabled = false;
            List<Accounts> animals;

            animals = (from p in db.user_logins
                       where p.ID == id
                       select new Accounts
                       {
                           ID = p.ID,
                           USERNAME = p.username,
                           PERMISSTION = p.permission
                       }).ToList();
            if (animals.Count > 0)
            {
                return animals[0];
            }
            else return null;
        }

        public List<Accounts> SelectByPermission(String permisstion)
        {
            db.ObjectTrackingEnabled = false;
            List<Accounts> animals;

            animals = (from p in db.user_logins
                       where p.permission == permisstion
                       select new Accounts
                       {
                           ID = p.ID,
                           USERNAME = p.username,
                           PERMISSTION = p.permission
                       }).ToList();

            return animals;
        }

        public List<Accounts> SelectByPermissionName(String permisstion, String keyword)
        {
            db.ObjectTrackingEnabled = false;
            List<Accounts> animals;

            animals = (from p in db.user_logins
                       where p.permission == permisstion && p.username == keyword
                       select new Accounts
                       {
                           ID = p.ID,
                           USERNAME = p.username,
                           PERMISSTION = p.permission
                       }).ToList();

            return animals;
        }

        public bool LoginAccount(String user, String pass)
        {
            db.ObjectTrackingEnabled = false;
            List<user_login> users;
            String passHash = CreateMD5(pass);
            users = (from p in db.user_logins
                     where p.username == user && p.password == passHash
                     select p).ToList();

            if (users.Count > 0) return true;
            else return false;
        }

        public int CheckPermission(String user)
        {
            db.ObjectTrackingEnabled = false;
            List<user_login> users;

            users = (from p in db.user_logins
                     where p.username == user
                     select p).ToList();

            switch(users[0].permission)
            {
                case "admin":
                    {
                        return 4;
                    }
                case "boss":
                    {
                        return 3;
                    }
                case "manage":
                    {
                        return 2;
                    }
                case "personnel":
                    {
                        return 1;
                    }
                default: return -1;
            }
        }

        public class Accounts
        {
            public String ID { get; set; }
            public String USERNAME { get; set; }
            public String PERMISSTION { get; set; }
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}