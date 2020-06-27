using HTQLNhanSu.DAL;
using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLNhanSu.BUS
{
    public class ManageBUS
    {
        public List<employee> SelectALL(String user, String token)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new ManageDAOSQL().SelectALL();
            }
            else return new List<employee>();
        }

        public bool InsertEmploy(employee employee, String username, String token)
        {
            if(new LoginDAOFirebase().CheckToken(username,token))
            {
                if (new LoginDAOSQL().CheckPermission(username) == 3 || new LoginDAOSQL().CheckPermission(username) == 4)
                {
                    bool check = new ManageDAOSQL().InsertEmploy(employee);
                    if (check)
                    {
                        new LoginDAOFirebase().History(username, "Thêm thành công ID" + employee.ID);
                    }
                    else
                    {
                        new LoginDAOFirebase().History(username, "Thêm thất bại ID" + employee.ID);
                    }
                    return check;
                }
                else
                {
                    new LoginDAOFirebase().History(username, "Thêm thất bại ID" + employee.ID);
                    return false;
                }
            }
            new LoginDAOFirebase().History(username, "Thêm thất bại ID" + employee.ID);
            return false;
        }

        public bool UpdateEmploy(employee employee, String username, String token)
        {
            if (new LoginDAOFirebase().CheckToken(username, token))
            {
                if (new LoginDAOSQL().CheckPermission(username) == 3 || new LoginDAOSQL().CheckPermission(username) == 4)
                {
                    bool check = new ManageDAOSQL().UpdateEmploy(employee);
                    if (check)
                    {
                        new LoginDAOFirebase().History(username, "Cập nhật thành công ID" + employee.ID);
                    }
                    else
                    {
                        new LoginDAOFirebase().History(username, "Cập nhật thất bại ID" + employee.ID);
                    }
                    return check;
                }
                else
                {
                    new LoginDAOFirebase().History(username, "Cập nhật thất bại ID" + employee.ID);
                    return false;
                }
            }
            new LoginDAOFirebase().History(username, "Cập nhật thất bại ID" + employee.ID);
            return false;
        }

        public bool DeleteEmploy(employee employee, String username, String token)
        {
            if (new LoginDAOFirebase().CheckToken(username, token))
            {
                if (new LoginDAOSQL().CheckPermission(username) == 3 || new LoginDAOSQL().CheckPermission(username) == 4)
                {

                    bool check = new ManageDAOSQL().DeleteEmploy(employee);
                    if (check)
                    {
                        new LoginDAOFirebase().History(username, "Xóa thành công ID" + employee.ID);
                    }
                    else
                    {
                        new LoginDAOFirebase().History(username, "Xóa thất bại ID" + employee.ID);
                    }
                    return check;
                }
                else
                {
                    new LoginDAOFirebase().History(username, "Xóa thất bại ID" + employee.ID);
                    return false;
                }
            }
            new LoginDAOFirebase().History(username, "Xóa thất bại ID" + employee.ID);
            return false;
        }

        public List<employee> SelectByName(String user, String token, String keyword)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new ManageDAOSQL().SelectByName(keyword);
            }
            else return new List<employee>();
        }

        public employee SelectByID(String user, String token, String id)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new ManageDAOSQL().SelectByID(id);
            }
            else return new employee();
        }

        public List<employee> SelectByDepartmentName(String user, String token, String department, String keyword)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new ManageDAOSQL().SelectByDepartmentName(department, keyword);
            }
            else return new List<employee>();
        }

        public List<employee> SelectByDepartment(String user, String token, String department)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new ManageDAOSQL().SelectByDepartment(department);
            }
            else return new List<employee>();
        }
    }
}