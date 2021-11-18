using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomData_Database_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            CustomData_Database_Test.Models.Animal _Animal = new Models.Animal();

            _Animal.RecordId = 123;
            _Animal.Name = "dave, hasselhoff";
            _Animal.Data_Transaction_Status = true;
            _Animal.Data_Transaction_Message = "Data Select was successful.";

            _Animal.Data_Insert(_Animal);

            _Animal.RecordId = 333;
            _Animal.Name = "dave, , qweqwe";
            _Animal.Data_Transaction_Status = true;
            _Animal.Data_Transaction_Message = "Data Select was successful.";

            _Animal.Data_Update(_Animal);


            _Animal.Data_Select(_Animal);


            var asd = _Animal.RecordId;

            return View();
        }
    }
}