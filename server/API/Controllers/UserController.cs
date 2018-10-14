

//------

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using API.Models;


namespace API.Controllers
{

  [EnableCors("*", "*", "*")]
  public class UserController : ApiController
  {

    [HttpPost]
    [Route("Login")]
    public HttpResponseMessage Login([FromBody] User user)
    {
      lock (GlobalProp.UserList)
      {
        User userExists = GlobalProp.UserList.Find(p => p.UserName == user.UserName);
        if (userExists != null)
          return Request.CreateResponse(HttpStatusCode.Forbidden, "User name is exists, choose another username.");
      }
      if (!ModelState.IsValid)
        foreach (ModelState modelState in ModelState.Values)
        {
          foreach (ModelError error in modelState.Errors)
          {
            return Request.CreateResponse(HttpStatusCode.BadRequest, error);
          }
        }
      GlobalProp.UserList.Add(user);
      return Request.CreateResponse(HttpStatusCode.OK, "true");
    }

    [HttpGet]
    [Route("GetUsers")]
    public HttpResponseMessage GetUsers()
    {
      lock (GlobalProp.UserList)
      {
        List<User> waitingUsers = GlobalProp.UserList.FindAll(p => p.PartnerUserName == null);
        return Request.CreateResponse(HttpStatusCode.OK, waitingUsers);
      }

    }

    [HttpGet]
    [Route("GetCurrentUser/{userName}")]
    public HttpResponseMessage GetCurrentUser(string userName)
    {
      lock (GlobalProp.UserList)
      {
        User currentUser = GlobalProp.UserList.Find(p => p.UserName == userName);
        return Request.CreateResponse(HttpStatusCode.OK, currentUser);
      }
    }

    [HttpPut]
    [Route("ChoosePatner/{partnerName}")]
    public HttpResponseMessage ChoosePatner(string partnerName, [FromBody] string CurrentUser)
    {
      lock (GlobalProp.UserList)
      {
        User currentUser = GlobalProp.UserList.Find(p => p.UserName == CurrentUser);
        User partner = GlobalProp.UserList.Find(p => p.UserName == partnerName);
        if (partner.PartnerUserName != null)
          return Request.CreateResponse(HttpStatusCode.BadRequest, "Choose another partner.");
        if (currentUser.PartnerUserName != null)
          return Request.CreateResponse(HttpStatusCode.BadRequest, "You have already been choosen to a game.");
        if (partnerName == CurrentUser)
          return Request.CreateResponse(HttpStatusCode.BadRequest, "You can't choose yourself.");
        currentUser.PartnerUserName = partnerName;
        partner.PartnerUserName = CurrentUser;
        Game newGame = new Game() { Player1 = currentUser, Player2 = partner, CurrentTurn = currentUser.UserName };
        GlobalProp.GameList.Add(newGame);
        return Request.CreateResponse(HttpStatusCode.OK, "true");

      }

    }



  }
}


