using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace ProAngular.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Post([FromBody]UserInfo info)
        {
            if (info.UserName == "admin" && info.Password == "secret")
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
        }
    }

    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
