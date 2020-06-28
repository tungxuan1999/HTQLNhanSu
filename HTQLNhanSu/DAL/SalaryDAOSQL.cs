using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLNhanSu.DAL
{
    public class SalaryDAOSQL
    {
        static String strCon = "Data Source=den1.mssql8.gear.host;Persist Security Info=True;User ID=employeeat;Password=Cy5PUI-v9-4j";
        private DataSalaryDataContext dbSalary = new DataSalaryDataContext(strCon);
        private DataPaymentDataContext dbPayment = new DataPaymentDataContext(strCon);

        public List<salary> SelectALLSalary()
        {
            dbSalary.ObjectTrackingEnabled = false;
            List<salary> salaries = dbSalary.salaries.ToList();
            return salaries;
        }

        public List<payment> SelectALLPayment()
        {
            dbPayment.ObjectTrackingEnabled = false;
            List<payment> payments = dbPayment.payments.ToList();
            return payments;
        }

        public bool Update(payment p)
        {
            try
            {
                payment data = dbPayment.payments.SingleOrDefault(Login => Login.ID == p.ID);
                if (data != null)
                {
                    data.ID = p.ID;
                    data.Name = p.Name;
                    data.Position = p.Position;
                    data.Salary = p.Salary;
                    data.Workingdays = p.Workingdays;
                    data.Bonus = p.Bonus;
                    dbPayment.SubmitChanges();
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

        public List<payment> SelectByName(String keyword)
        {
            dbPayment.ObjectTrackingEnabled = false;
            List<payment> animals;

            animals = (from p in dbPayment.payments
                       where p.Name.Contains(keyword)
                       select p).ToList();
            return animals;

        }

        public payment SelectByID(String id)
        {
            dbPayment.ObjectTrackingEnabled = false;
            List<payment> animals;

            animals = (from p in dbPayment.payments
                       where p.ID == id
                       select p).ToList();
            if (animals.Count > 0)
            {
                return animals[0];
            }
            else return new payment();
        }

        public List<payment> SelectByPositionName(String position, String keyword)
        {
            dbPayment.ObjectTrackingEnabled = false;
            List<payment> animals;

            animals = (from p in dbPayment.payments
                       where p.Name.Contains(keyword) && p.Position == position
                       select p).ToList();
            return animals;
        }

        public List<payment> SelectByPosition(String position)
        {
            dbPayment.ObjectTrackingEnabled = false;
            List<payment> animals;

            animals = (from p in dbPayment.payments
                       where p.Position == position
                       select p).ToList();
            return animals;
        }
    }
}