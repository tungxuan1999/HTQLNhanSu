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
    class AccountBUS
    {
        private String URL = DataStatic.urlHost;

        public String LoginAccount(Account account)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(account);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString(new Uri(URL + "api/login"), "POST", data);
            return JsonConvert.DeserializeObject<String>(response);
        }

        public List<Accounts> GETALL(String user, String token)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/login?user=" + user + "&token=" + token));
            return JsonConvert.DeserializeObject<List<Accounts>>(response);
        }

        public List<Accounts> SelectByPermisstion(String user, String token, String permisstion)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/account?user=" + user + "&token=" + token + "&permisstion=" + permisstion));
            return JsonConvert.DeserializeObject<List<Accounts>>(response);
        }

        public List<Accounts> SelectByName(String user, String token, String keyword)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/account?user=" + user + "&token=" + token + "&keyword=" + keyword));
            return JsonConvert.DeserializeObject<List<Accounts>>(response);
        }

        public List<Accounts> SelectByPermisstionName(String user, String token, String permisstion, String keyword)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/account?user=" + user + "&token=" + token + "&permisstion=" + permisstion + "&keyword=" + keyword));
            return JsonConvert.DeserializeObject<List<Accounts>>(response);
        }

        public List<String> GetKey()
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api/login"));
            return JsonConvert.DeserializeObject<List<String>>(response);
        }

        public bool Insert(TokenChange f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString(new Uri(URL + "api/account"), "POST", data);
            return Boolean.Parse(response);
        }

        public bool Update(TokenChange f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString(new Uri(URL + "api/account"), "PUT", data);
            return Boolean.Parse(response);
        }

        public bool Delete(TokenChange f)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            String data = JsonConvert.SerializeObject(f);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString(new Uri(URL + "api/account"), "DELETE", data);
            return Boolean.Parse(response);
        }

        public class Account
        {
            public String USER { get; set; }
            public String PASS { get; set; }

            public Account(string uSER, string pASS)
            {
                USER = uSER;
                PASS = pASS;
            }
        }

        public class Accounts
        {
            public String ID { get; set; }
            public String USERNAME { get; set; }
            public String PERMISSTION { get; set; }
        }

        public class USERLOGIN
        {
            public String ID { get; set; }
            public String username { get; set; }
            public String permisstion { get; set; }
            public String password { get; set; }
        }

        public class TokenChange
        {
            public USERLOGIN user { get; set; }
            public String username { get; set; }
            public String token { get; set; }
        }
    }
}
