using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ProAngular.Controllers
{
    public class Ch1Controller : ApiController
    {       
        public HttpResponseMessage Get()
        {
            var json =
                "[{\"action\":\"Buy Flowers\",\"done\":false},{\"action\":\"Get Shoes\",\"done\":false},{\"action\":\"Collect Tickets\",\"done\":true},{\"action\":\"Call Joe\",\"done\":false}]";
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
