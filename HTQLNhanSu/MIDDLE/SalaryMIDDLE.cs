using HTQLNhanSu.DAL;
using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLNhanSu.MIDDLE
{
    public class SalaryMIDDLE
    {
        public List<salary> SelectALLSalary(String user, String token)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new SalaryDAOSQL().SelectALLSalary();
            }
            else return new List<salary>();
        }

        public List<payment> SelectALLPayment(String user, String token)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new SalaryDAOSQL().SelectALLPayment();
            }
            else return new List<payment>();
        }

        public bool Update(String user, String token, payment p)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                bool check = new SalaryDAOSQL().Update(p);
                if(check)
                {
                    new LoginDAOFirebase().History(user, "Cập nhật payment thành công " + p.ID);
                }
                else
                {
                    new LoginDAOFirebase().History(user, "Cập nhật payment thất bại " + p.ID);
                }
                return check;
            }
            else
            {
                new LoginDAOFirebase().History(user, "Cập nhật payment thất bại " + p.ID);
                return false;
            }
        }

        public List<payment> SelectByName(String user, String token, String keyword)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new SalaryDAOSQL().SelectByName(keyword);
            }
            else return new List<payment>();
        }

        public payment SelectByID(String user, String token, String id)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new SalaryDAOSQL().SelectByID(id);
            }
            else return new payment();
        }

        public List<payment> SelectByPositionName(String user, String token, String department, String keyword)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new SalaryDAOSQL().SelectByPositionName(department, keyword);
            }
            else return new List<payment>();
        }

        public List<payment> SelectByPosition(String user, String token, String department)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new SalaryDAOSQL().SelectByPosition(department);
            }
            else return new List<payment>();
        }
    }
}