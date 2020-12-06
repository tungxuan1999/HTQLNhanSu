using HTQLNhanSu.DAL;
using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HTQLNhanSu.BUS
{
    public class LoginBUS
    {
        public String Login(String user, String pass)
        {
            if (new LoginDAOSQL().LoginAccount(user, pass))
            {
                String token = getRandomToken();
                new LoginDAOFirebase().LoginToken(user, token);
                if (token != "")
                {
                    new LoginDAOFirebase().History(user, "Đăng nhập thành công");
                }
                else
                {
                    new LoginDAOFirebase().History(user, "Đăng nhập thất bại");
                }
                return token;
            }
            else return "";
        }

        public List<LoginDAOSQL.Accounts> SelectALL(String user, String token)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new LoginDAOSQL().SelectALL();
            }
            else return new List<LoginDAOSQL.Accounts>();
        }

        public List<LoginDAOSQL.Accounts> SelectByPermisstion(String user, String token, String permisstion)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new LoginDAOSQL().SelectByPermission(permisstion);
            }
            else return new List<LoginDAOSQL.Accounts>();
        }

        public List<LoginDAOSQL.Accounts> SelectByName(String user, String token, String keyword)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new LoginDAOSQL().SelectByName(keyword);
            }
            else return new List<LoginDAOSQL.Accounts>();
        }

        public List<LoginDAOSQL.Accounts> SelectByPermisstionName(String user, String token, String permisstion, String keyword)
        {
            if (new LoginDAOFirebase().CheckToken(user, token))
            {
                return new LoginDAOSQL().SelectByPermissionName(permisstion, keyword);
            }
            else return new List<LoginDAOSQL.Accounts>();
        }

        public bool InsertAccount(user_login user, String username, String token)
        {
            if (new LoginDAOFirebase().CheckToken(username, token))
            {
                if (new LoginDAOSQL().CheckPermission(username) > 1)
                {
                    bool check = new LoginDAOSQL().InsertAccount(user);
                    if (check)
                    {
                        new LoginDAOFirebase().History(username, "Đăng ký thành công tài khoản " + user.username);
                    }
                    else
                    {
                        new LoginDAOFirebase().History(username, "Đăng ký thất bại tài khoản " + user.username);
                    }
                    return check;
                }
                else
                {
                    new LoginDAOFirebase().History(username, "Đăng ký thất bại tài khoản " + user.username);
                    return false;
                }
            }
            else
            {
                new LoginDAOFirebase().History(username, "Đăng ký thất bại tài khoản " + user.username);
                return false;
            }
        }

        public bool UpdateAccount(user_login user, String username, String token)
        {
            if (new LoginDAOFirebase().CheckToken(username, token))
            {
                if (user.username == username || new LoginDAOSQL().CheckPermission(username) > new LoginDAOSQL().CheckPermission(user.username))
                {
                    bool check = new LoginDAOSQL().UpdateAccount(user);
                    if (check)
                    {
                        new LoginDAOFirebase().History(username, "Cập nhật thành công tài khoản " + user.username);
                    }
                    else
                    {
                        new LoginDAOFirebase().History(username, "Cập nhật thất bại tài khoản " + user.username);
                    }
                    return check;
                }
                else
                {
                    new LoginDAOFirebase().History(username, "Cập nhật thất bại tài khoản " + user.username);
                    return false;
                }
            }
            else
            {
                new LoginDAOFirebase().History(username, "Cập nhật thất bại tài khoản " + user.username);
                return false;
            }
        }

        public bool DeleteAccount(user_login user, String username, String token)
        {
            if (new LoginDAOFirebase().CheckToken(username, token))
            {
                if (user.username == username || new LoginDAOSQL().CheckPermission(username) > new LoginDAOSQL().CheckPermission(user.username))
                {
                    bool check = new LoginDAOSQL().DeleteAccount(user);
                    if (check)
                    {
                        new LoginDAOFirebase().History(username, "Xóa thành công tài khoản " + user.username);
                    }
                    else
                    {
                        new LoginDAOFirebase().History(username, "Xóa thất bại tài khoản " + user.username);
                    }
                    return check;
                }
                else
                {
                    new LoginDAOFirebase().History(username, "Xóa thất bại tài khoản " + user.username);
                    return false;
                }
            }
            else
            {
                new LoginDAOFirebase().History(username, "Xóa thất bại tài khoản " + user.username);
                return false;
            }
        }

        string getRandomToken()
        {
            Random random = new Random();
            int sttran = random.Next(100, 200);
            char[] array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'O', 'P', 'Q', 'R', 'S', 'X', 'M', 'N', 'T', 'V', 'W' };
            string result = "";
            for (int i = 0; i < sttran; i++)
            {
                result += array[random.Next(0, 31)];
            }
            return result;
        }
    }
}