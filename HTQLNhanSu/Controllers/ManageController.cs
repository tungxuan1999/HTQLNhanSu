using HTQLNhanSu.BUS;
using HTQLNhanSu.DAL;
using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTQLNhanSu.Controllers
{
    public class ManageController : ApiController
    {

        [HttpGet]
        [Route("api/getkey")]
        public IHttpActionResult GetKey()
        {
            return Json(new ManageDAOSQL().GetKey());
        }

        [HttpGet]
        [Route("api/manage")]
        public IHttpActionResult SelectAll(String user, String token)
        {
            return Json(new ManageBUS().SelectALL(user, token));
        }

        [HttpGet]
        [Route("api/manage/searchbyid")]
        public IHttpActionResult SelectByID(String ID, String user, String token)
        {
            return Json(new ManageBUS().SelectByID(user, token, ID));
        }

        [HttpGet]
        [Route("api/manage")]
        public IHttpActionResult SelectByName(String keyword, String user, String token)
        {
            return Json(new ManageBUS().SelectByName(user, token, keyword));
        }

        [HttpGet]
        [Route("api/manage")]
        public IHttpActionResult SelectByDepartment(String department, String user, String token)
        {
            return Json(new ManageBUS().SelectByDepartment(user, token, department));
        }

        [HttpGet]
        [Route("api/manage")]
        public IHttpActionResult SelectByDepartmentName(String department, String keyword, String user, String token)
        {
            return Json(new ManageBUS().SelectByDepartmentName(user, token, department, keyword));
        }

        [HttpPost]
        [Route("api/manage")]
        public IHttpActionResult Insert(FilePut f)
        {
            return Json(new ManageBUS().InsertEmploy(f.EMPLOYEE, f.USER, f.TOKEN));
        }

        [HttpPut]
        [Route("api/manage")]
        public IHttpActionResult Update(FilePut f)
        {
            return Json(new ManageBUS().UpdateEmploy(f.EMPLOYEE, f.USER, f.TOKEN));
        }

        [HttpDelete]
        [Route("api/manage")]
        public IHttpActionResult Delete(FilePut f)
        {
            return Json(new ManageBUS().DeleteEmploy(f.EMPLOYEE, f.USER, f.TOKEN));
        }

        [HttpPost]
        [Route("api/getimage")]
        public IHttpActionResult GetImage(ImageChange imageChange)
        {
            return Json(new ManageBUS().GetImage(imageChange.username, imageChange.token, imageChange.id));
        }

        [HttpPost]
        [Route("api/postimage")]
        public IHttpActionResult PostImage(ImageChange imageChange)
        {
            return Json(new ManageBUS().PostImage(imageChange.username, imageChange.token, imageChange.imagebitmap, imageChange.id));
        }

        public class ImageChange
        {
            public String username { get; set; }
            public String token { get; set; }
            public String imagebitmap { get; set; }
            public String id { get; set; }
        }

        public class FilePut
        {
            public employee EMPLOYEE { get; set; }
            public String USER { get; set; }
            public String TOKEN { get; set; }
        }
    }
}
