//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using BL;
//using System.Data.Entity;
//using Models;
//using System.Web.Http.Cors;

//namespace API.Controllers
//{
//    [EnableCors("*", "*", "*")]
//    public class EnterController : ApiController
//    {
//        [HttpGet]
//        [Route("api/login/{email}/{password}")]
//        public HttpResponseMessage userLogin([FromUri] string email,[FromUri]string password)
//        {
//            try
//            {
//                Users user = Enter.getUser(password, email);
//                return Request.CreateResponse(HttpStatusCode.OK,user);
//            }
//            catch (Exception ex)
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex.Message);
//            }
//        }
//        [HttpPost]
//        [Route("api/register")]
//        public HttpResponseMessage AddUser([FromBody] Users user)
//        {
//            int newUserId = Enter.register(user);
//            if (newUserId!=0)
//                return Request.CreateResponse(HttpStatusCode.Created, newUserId);
//            return null;
//        }
//    }
//}
