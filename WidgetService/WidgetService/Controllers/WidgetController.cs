using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WidgetService.Models;

namespace WidgetService.Controllers
{
       
    public class WidgetController : ApiController
    {

        private const string BARKLEY = "1bb243e9-c1ef-433f-9385-1ee7b1947bfc";
        private const string CARLO = "049ac34a-8ef3-48ff-ad31-68e36a0cd769";


        // GET: api/Widget
        [HttpPost]
        public HttpResponseMessage GetWidgets()
        {
            //check to see if the auth header exists
            int authHeaderCount = Request.Headers.Where ( h => h.Key.ToLower ( ) == "auth" ).Count ( );
            if(  authHeaderCount != 1)
                return  Request.CreateErrorResponse (System.Net.HttpStatusCode.Unauthorized, "Missing Header", new UnauthorizedAccessException("User Must Authenticate") );

            //grab the header
            var tokenHeader = Request.Headers.GetValues ( "Auth" ).First ( );
            if(tokenHeader == BARKLEY || tokenHeader == CARLO)
            {
                // proceed
                Random x =  new Random();
                int count = x.Next ( 5, 25 );
                
                List<Widget> list = new List<Widget>();
                for (int i = 0; i < count; i++)
                    list.Add ( new Widget() { Code = x.Next ( 1, 100 ), Description = "Widget Description " + i, Name = "Widget " + i } );

                var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

                json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

                return Request.CreateResponse ( System.Net.HttpStatusCode.OK, list );

            }

             return Request.CreateErrorResponse ( System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException(string.Format ( "Invalid Token {0}", tokenHeader )) );

            
        }


    }
}
