using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLNhanSu.DAL
{
    public class ManageDAOSQL
    {
        static String strCon = "Data Source=den1.mssql8.gear.host;Persist Security Info=True;User ID=employeeat;Password=Cy5PUI-v9-4j";
        private DataManageDataContext db = new DataManageDataContext(strCon);

        public List<employee> SelectALL()
        {
            db.ObjectTrackingEnabled = false;
            List<employee> employees = db.employees.ToList<employee>();
            return employees;
        }

        public bool InsertEmploy(employee login)
        {
            try
            {
                db.employees.InsertOnSubmit(login);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEmploy(employee login)
        {
            try
            {
                employee data = db.employees.SingleOrDefault(Login => Login.ID == login.ID);
                if (data != null)
                {
                    data.ID = login.ID;
                    if (login.Address != null)
                    {
                        data.Address = login.Address;
                    }
                    data.Department = data.Department;
                    if (login.Email != null)
                    {
                        data.Email = login.Email;
                    }
                    data.Position = login.Position;
                    data.Name = login.Name;
                    if (login.Birthday != new DateTime())
                    {
                        data.Birthday = login.Birthday;
                    }
                    if (login.Image != null)
                    {
                        data.Image = login.Image;
                    }
                    if (login.Gender != null)
                        data.Gender = login.Gender;
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

        public bool DeleteEmploy(employee login)
        {
            try
            {
                employee animal = db.employees.Single(u => u.ID == login.ID);
                db.employees.DeleteOnSubmit(animal);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<employee> SelectByName(String keyword)
        {
            db.ObjectTrackingEnabled = false;
            List<employee> animals;

            animals = (from p in db.employees
                       where p.Name.Contains(keyword)
                       select p).ToList();
            return animals;

        }

        public employee SelectByID(String id)
        {
            db.ObjectTrackingEnabled = false;
            List<employee> animals;

            animals = (from p in db.employees
                       where p.ID == id
                       select p).ToList();
            if (animals.Count > 0)
            {
                return animals[0];
            }
            else return new employee();
        }

        public List<employee> SelectByDepartmentName(String department, String keyword)
        {
            db.ObjectTrackingEnabled = false;
            List<employee> animals;

            animals = (from p in db.employees
                       where p.Name.Contains(keyword) && p.Department == department
                       select p).ToList();
            return animals;
        }

        public List<employee> SelectByDepartment(String department)
        {
            db.ObjectTrackingEnabled = false;
            List<employee> animals;

            animals = (from p in db.employees
                       where p.Department == department
                       select p).ToList();
            return animals;
        }

        public Key GetKey()
        {
            Key key = new Key();

            key.LISTposition = new List<string>();
            key.LISTposition.Add("ADMIN");
            key.LISTposition.Add("Giám đốc");
            key.LISTposition.Add("Phó giám đốc");
            key.LISTposition.Add("Thư ký");
            key.LISTposition.Add("Trưởng phòng");
            key.LISTposition.Add("Phó phòng");
            key.LISTposition.Add("Nhân viên");

            key.LISTdepartment = new List<string>();
            key.LISTdepartment.Add("Ban quản lý");
            key.LISTdepartment.Add("Ban giám đốc");
            key.LISTdepartment.Add("Ban kế toán");
            key.LISTdepartment.Add("Ban kĩ thuật");
            key.LISTdepartment.Add("Ban marketing");
            key.LISTdepartment.Add("Ban sản xuất");

            return key;
        }

        public class Key
        {
            public List<String> LISTposition { get; set; }
            public List<String> LISTdepartment { get; set; }
        }
    }
}