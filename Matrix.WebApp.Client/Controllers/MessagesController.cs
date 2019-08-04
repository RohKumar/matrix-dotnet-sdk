using Matrix.Client;
using Matrix.WebApp.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.WebApp.Client.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadMessages(string ID)
        {

            MatrixRoom[] rooms = TempData.Get<MatrixRoom[]>("key");
            MessagesViewModel mvm = new MessagesViewModel();
            foreach (var room in rooms)
            {
                if (room.ID == ID)
                {
                    mvm.messages = room.Messages;
                }
            }
            return View(mvm);
        }

        //[HttpGet]
        //public ActionResult ReadMessages()
        //{
        //    return View();
        //}
    }
}