using Client.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.BL
{
    class SalaryBUS
    {
        private String URL = DataStatic.urlHost;

        public List<salary> SelectALLSalary(String user, String token)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/salary?user=" + user + "&token=" + token));
            return JsonConvert.DeserializeObject<List<salary>>(response);
        }

        public List<payment> SelectALLPayment(String user, String token)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/payment?user=" + user + "&token=" + token));
            return JsonConvert.DeserializeObject<List<payment>>(response);
        }

        public List<String> GetKey()
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/payment"));
            return JsonConvert.DeserializeObject<List<String>>(response);
        }

        public List<payment> SelectByName(String user, String token, String keyword)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/payment?user=" + user + "&token=" + token+"&keyword="+keyword));
            return JsonConvert.DeserializeObject<List<payment>>(response);
        }

        public List<payment> SelectByPosition(String user, String token, String position)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/payment?user=" + user + "&token=" + token+"&position="+position));
            return JsonConvert.DeserializeObject<List<payment>>(response);
        }

        public List<payment> SelectByPositionName(String user, String token, String position, String keyword)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/payment?user=" + user + "&token=" + token+"&position="+position+"&keyword="+keyword));
            return JsonConvert.DeserializeObject<List<payment>>(response);
        }

        //public bool Update...
        public bool Update(FilePut f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.UploadString(new Uri(URL + "api/payment"), "PUT", data);
            return Boolean.Parse(response);
        }

        public class salary
        {
            public String Position { get; set; }
            public int Salary { get; set; }
            public int Bonus { get; set; }
            public int Allowance { get; set; }
            public int DBonus { get; set; }
        }

        public class payment
        {
            public String ID { get; set; }
            public String Name { get; set; }
            public String Position { get; set; }
            public int Workingdays { get; set; }
            public int Bonus { get; set; }
            public int Salary { get; set; }
        }

        public class FilePut
        {
            public String USER { get; set; }
            public String TOKEN { get; set; }
            public payment payment { get; set; }
            public FilePut(string uSER,string tOKEN,payment pAYMENT)
            {
                USER = uSER;
                TOKEN = tOKEN;
                payment = pAYMENT;
            }
        }
    }
}
