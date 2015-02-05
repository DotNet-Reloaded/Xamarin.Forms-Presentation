using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WidgetService.Models;

namespace WidgetService.Controllers
{
    public class AuthController : ApiController
    {
        private const string BARKLEY = "1bb243e9-c1ef-433f-9385-1ee7b1947bfc";
        private const string CARLO = "049ac34a-8ef3-48ff-ad31-68e36a0cd769";
        [HttpPost]
        public HttpResponseMessage Authenticate([FromBody] AuthRequest request)
        {
            AuthResponse auth = null;

            if (request.UserName.ToLower() == "barkley")
            {
                auth = new AuthResponse() { ID = "1", Token = BARKLEY };
            }

            if (request.UserName.ToLower() == "carlo")
            {
                auth = new AuthResponse() { ID = "2", Token = CARLO };
            }


            if (auth == null)
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, string.Format("{0} unauthorized", request.UserName), new UnauthorizedAccessException());


            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;


            return Request.CreateResponse(HttpStatusCode.OK, auth, json);
        }
    }
}
