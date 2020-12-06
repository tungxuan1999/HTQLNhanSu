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

        public String GetImage(String user, String token, String id)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                if (new LoginDAOSQL().CheckPermission(user) > 2)
                {
                    return new LoginDAOFirebase().GetImage(id);
                }
                else return "";
            }
            else
                return "";
        }

        public String PostImage(String user, String token, String imagebitmap, String id)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                if (new LoginDAOSQL().CheckPermission(user) > 2)
                {
                    if (new LoginDAOFirebase().PostImage(imagebitmap, id))
                    {
                        new LoginDAOFirebase().History(user, "Upload image " + id + " success");
                        employee employee = new ManageDAOSQL().SelectByID(id);
                        employee.Image = "Yes";
                        employee.Address = null;
                        employee.Birthday = new DateTime();
                        employee.Email = null;
                        employee.Gender = null;
                        new ManageDAOSQL().UpdateEmploy(employee);
                        return "Upload hình thành công";
                    }
                    else
                    {
                        new LoginDAOFirebase().History(user, "Upload image " + id + " fail");
                        return "Upload hình thất bại";
                    }
                }
                else
                {
                    new LoginDAOFirebase().History(user, "Upload image " + id + " fail, not permission");
                    return "Không có quyền truy cập";
                }
            }
            else
            {
                new LoginDAOFirebase().History(user, "Upload image " + id + " fail, token fail");
                return "Upload hình thất bại sai token";
            }
        }
    }
}