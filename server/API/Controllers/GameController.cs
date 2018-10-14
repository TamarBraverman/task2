
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Models;

namespace API.Controllers
{
  [EnableCors("*", "*", "*")]
  public class GameController : ApiController
  {
    [HttpGet]
    [Route("GetAllCards/{userName}")]
    public HttpResponseMessage GetAllCards(string userName)
    {
      Game currentGame = GlobalProp.GameList.Find(p => p.Player1.UserName == userName || p.Player2.UserName == userName);
      lock (currentGame)
      {
        return Request.CreateResponse(HttpStatusCode.OK, new { cards = currentGame.CardArray, currentTurn = currentGame.CurrentTurn });
      }
    }
    [HttpPut]
    [Route("ChooseTwoCards/{userName}")]
    public HttpResponseMessage ChooseTwoCards(string userName, [FromBody]string[] cardsArray)
    {
      Game currentGame;
      int pointsPlayer1;
      int pointsPlayer2;

      currentGame = GlobalProp.GameList.Find(p => p.Player1.UserName == userName || p.Player2.UserName == userName);
      lock (currentGame.CardArray ) {

        if (currentGame.CurrentTurn == currentGame.Player1.UserName)
          currentGame.CurrentTurn = currentGame.Player2.UserName;
        else currentGame.CurrentTurn = currentGame.Player1.UserName;
        if (cardsArray[0] == cardsArray[1])
        {
          currentGame.CurrentTurn = userName;
          currentGame.CardArray[cardsArray[0]] = userName;
          if (!currentGame.CardArray.ContainsValue(null))
          {

            pointsPlayer1 = currentGame.CardArray.Count(p => p.Value == currentGame.Player1.UserName);
            pointsPlayer2 = currentGame.CardArray.Count(p => p.Value == currentGame.Player2.UserName);
            if (pointsPlayer1 > pointsPlayer2)
              currentGame.Player1.Score++;
            else if (pointsPlayer1 < pointsPlayer2)
              currentGame.Player2.Score++;
            else
            {
              currentGame.Player2.Score++;
              currentGame.Player1.Score++;
            }
            //GlobalProp.GameList.Remove(currentGame);
          }
          return Request.CreateResponse(HttpStatusCode.OK, "true");
        }
        else return Request.CreateResponse(HttpStatusCode.OK, "WRONG");

      }
      
    }
  }

}
