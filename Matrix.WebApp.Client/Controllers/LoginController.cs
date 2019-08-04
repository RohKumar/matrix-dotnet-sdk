
using Matrix.Webapp.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Matrix.Client;
using Matrix.Structures;
using Matrix.WebApp.Client.Models;
using Matrix;


namespace Matrix.Webapp.Client.Controllers
{
    public class LoginController : Controller
    {
        const int MESSAGE_CAPACITY = 255;
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User userModel)
        {

            RoomsViewModel rooms = GetUserRooms(userModel);

            ViewData["userName"] = userModel.UserName;

            //TempData.Put("key", rooms);
            //TempData.Keep("key");
            ////TempData["mydata"] = rooms;

            return View(rooms);
        }


        [HttpGet]
        public ActionResult Read(string ID)
        {

            //RoomsViewModel rooms = TempData.Get<RoomsViewModel>("key");
            //MatrixAPI api = new MatrixAPI("https://matrix.org");
            //MessagesViewModel mvm = new MessagesViewModel();
            //ChunkedMessages messages = api.GetRoomMessages(ID);

            string userName = ViewData["userName"].ToString();
            string token = ViewData["token"].ToString();

            string homeserverUrl = "https://matrix.org";
            MatrixClient client;
          
            client = new MatrixClient(homeserverUrl);
            client.LoginWithToken(userName, token);

            RoomsViewModel rmv = new RoomsViewModel();
            rmv.rooms = client.GetAllRooms();
            // mvm.messages = ID.Messages;    


            return View();
        }

        private RoomsViewModel GetUserRooms(User userModel)
        {


            string homeserverUrl = "https://matrix.org";
            MatrixClient client;
            string username = userModel.UserName;
            string password = userModel.Password;
            client = new MatrixClient(homeserverUrl);
            MatrixLoginResponse login = client.LoginWithPassword(username, password);
            ViewData["token"] = login.access_token;

            client.StartSync();
            RoomsViewModel rmv = new RoomsViewModel();
            rmv.rooms= client.GetAllRooms();
            

            return rmv;
        }
    }

}