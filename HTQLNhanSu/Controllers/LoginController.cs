using HTQLNhanSu.BUS;
using HTQLNhanSu.DAL;
using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace HTQLNhanSu.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/login")]
        public IHttpActionResult GETALL(String user, String token)
        {
            return Json(new LoginBUS().SelectALL(user, token));
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(Account account)
        {
            return Json(new LoginBUS().Login(account.USER, account.PASS));
        }

        [HttpGet]
        [Route("api/login")]
        public IHttpActionResult GetKey()
        {
            List<String> listitem = new List<string>();
            listitem.Add("admin");
            listitem.Add("boss");
            listitem.Add("manage");
            listitem.Add("personnel");
            return Json(listitem);
        }

        [HttpGet]
        [Route("api/account")]
        public IHttpActionResult SelectPermisstion(String permisstion, String user, String token)
        {
            return Json(new LoginBUS().SelectByPermisstion(user, token, permisstion));
        }

        [HttpGet]
        [Route("api/account")]
        public IHttpActionResult SelectName(String keyword, String user, String token)
        {
            return Json(new LoginBUS().SelectByName(user, token, keyword));
        }

        [HttpGet]
        [Route("api/account")]
        public IHttpActionResult SelectPermisstionName(String permisstion, String user, String token, String keyword)
        {
            return Json(new LoginBUS().SelectByPermisstionName(user, token, permisstion, keyword));
        }

        [HttpPost]
        [Route("api/account")]
        public IHttpActionResult Insert(TokenChange tokenChange)
        {
            return Json(new LoginBUS().InsertAccount(tokenChange.user, tokenChange.username, tokenChange.token));
        }

        [HttpPut]
        [Route("api/account")]
        public IHttpActionResult Update(TokenChange tokenChange)
        {
            return Json(new LoginBUS().UpdateAccount(tokenChange.user, tokenChange.username, tokenChange.token));
        }

        [HttpDelete]
        [Route("api/account")]
        public IHttpActionResult Delete(TokenChange tokenChange)
        {
            return Json(new LoginBUS().DeleteAccount(tokenChange.user, tokenChange.username, tokenChange.token));
        }

        [HttpPost]
        [Route("api/getimage")]
        public IHttpActionResult GetImage(ImageChange imageChange)
        {
            return Json(new LoginBUS().GetImage(imageChange.username, imageChange.token, imageChange.id));
        }

        [HttpPost]
        [Route("api/postimage")]
        public IHttpActionResult PostImage(ImageChange imageChange)
        {
            return Json(new LoginBUS().PostImage(imageChange.username,imageChange.token,imageChange.imagebitmap,imageChange.id));
        }

        public class Account
        {
            public String USER { get; set; }
            public String PASS { get; set; }
        }

        public class TokenChange
        {
            public user_login user { get; set; }
            public String username { get; set; }
            public String token { get; set; }
        }

        public class ImageChange
        {
            public String username { get; set; }
            public String token { get; set; }
            public String imagebitmap { get; set; }
            public String id { get; set; }
        }
    }
}
