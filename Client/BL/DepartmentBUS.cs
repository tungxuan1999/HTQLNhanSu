using Client.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.BL
{
    class DepartmentBUS
    {
        private String URL = DataStatic.urlHost;

        public Key GetKey()
        {
            WebClient client = new WebClient();

            /* GetAll_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/getkey"));
            return JsonConvert.DeserializeObject<Key>(response);
        }

        public List<Employee> SelectALL(String user, String token)
        {
            WebClient client = new WebClient();

            /* GetAll_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/manage?user=" + user + "&token=" + token));
            return JsonConvert.DeserializeObject<List<Employee>>(response);
        }

        public Employee SelectByID(String user, String token, String ID)
        {
            WebClient client = new WebClient();

            /* GetAll_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/manage?user=" + user + "&token=" + token + "ID=" + ID));
            return JsonConvert.DeserializeObject<Employee>(response);
        }

        public List<Employee> SelectALLByName(String user, String token, String keyword)
        {
            WebClient client = new WebClient();

            /* GetAll_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/manage?user=" + user + "&token=" + token + "&keyword=" + keyword));
            return JsonConvert.DeserializeObject<List<Employee>>(response);
        }

        public List<Employee> SelectByDepartment(String user, String token, String department)
        {
            WebClient client = new WebClient();

            /* GetAll_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/manage?user=" + user + "&token=" + token + "&department=" + department));
            return JsonConvert.DeserializeObject<List<Employee>>(response);
        }

        public List<Employee> SelectByDepartmentName(String user, String token, String department, String keyword)
        {
            WebClient client = new WebClient();

            /* GetAll_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/manage?user=" + user + "&token=" + token + "&department=" + department + "&keyword=" + keyword));
            return JsonConvert.DeserializeObject<List<Employee>>(response);
        }

        public bool Insert(FilePut f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.UploadString(new Uri(URL + "api/manage"), "POST", data);
            return Boolean.Parse(response);
        }

        public bool Update(FilePut f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.UploadString(new Uri(URL + "api/manage"), "PUT", data);
            return Boolean.Parse(response);
        }

        public bool Delete(FilePut f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.UploadString(new Uri(URL + "api/manage"), "DELETE", data);
            return Boolean.Parse(response);
        }


        public class Key
        {
            public List<String> LISTposition { get; set; }
            public List<String> LISTdepartment { get; set; }

            public Key(List<string> lISTposition, List<string> lISTdepartment)
            {
                LISTposition = lISTposition;
                LISTdepartment = lISTdepartment;
            }
        }

        public class Employee
        {
            public String ID { get; set; }
            public String Name { get; set; }
            public String Address { get; set; }
            public String Email { get; set; }
            public String Position { get; set; }
            public String Department { get; set; }

            public Employee(string iD, string name, string address, string email, string position, string department)
            {
                ID = iD;
                Name = name;
                Address = address;
                Email = email;
                Position = position;
                Department = department;
            }
        }

        public class FilePut
        {
            public Employee EMPLOYEE { get; set; }
            public String USER { get; set; }
            public String TOKEN { get; set; }

            public FilePut(Employee eMPLOYEE, string uSER, string tOKEN)
            {
                EMPLOYEE = eMPLOYEE;
                USER = uSER;
                TOKEN = tOKEN;
            }
        }

    }
}
