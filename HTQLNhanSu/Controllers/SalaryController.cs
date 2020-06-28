using HTQLNhanSu.DAL;
using HTQLNhanSu.MIDDLE;
using HTQLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTQLNhanSu.Controllers
{
    public class SalaryController : ApiController
    {
        [HttpGet]
        [Route("api/salary")]
        public IHttpActionResult SelectALLSalary(String user, String token)
        {
            return Json(new SalaryMIDDLE().SelectALLSalary(user, token));
        }

        [HttpGet]
        [Route("api/payment")]
        public IHttpActionResult SelectALLPayment(String user, String token)
        {
            return Json(new SalaryMIDDLE().SelectALLPayment(user, token));
        }

        [HttpPut]
        [Route("api/payment")]
        public IHttpActionResult Update(FilePut f)
        {
            return Json(new SalaryMIDDLE().Update(f.USER, f.TOKEN, f.payment));
        }

        [HttpGet]
        [Route("api/payment")]
        public IHttpActionResult SelectByName(String user, String token, String keyword)
        {
            return Json(new SalaryMIDDLE().SelectByName(user, token, keyword));
        }

        [HttpGet]
        [Route("api/payment")]
        public IHttpActionResult SelectByID(String user, String token, String ID)
        {
            return Json(new SalaryMIDDLE().SelectByID(user, token, ID));
        }

        [HttpGet]
        [Route("api/payment")]
        public IHttpActionResult SelectByPositionName(String user, String token, String position, String keyword)
        {
            return Json(new SalaryMIDDLE().SelectByPositionName(user, token, position, keyword));
        }

        [HttpGet]
        [Route("api/payment")]
        public IHttpActionResult SelectByPosition(String user, String token, String position)
        {
            return Json(new SalaryMIDDLE().SelectByPosition(user, token, position));
        }

        public class FilePut
        {
            public String USER { get; set; }
            public String TOKEN { get; set; }
            public payment payment { get; set; }
        }
    }
}
