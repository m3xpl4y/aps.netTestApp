using System.Web.Mvc;
using TestApp.Data;
using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string query2 = "select person.firstname, person.lastname, person.age, address.street, address.city from customer.person, customer.address where person_id = person.id;";
            string query = "SELECT * FROM person";
            string query3 = "SELECT * FROM address";
            DbManager dbm = new DbManager();
            List<PersonAdresses> persons = dbm.PA_Reader(dbm.Connect(query2), dbm.SQLConnection());

            PersonAdressViewModel pav = dbm.PersonAdressViewModel(dbm.Connect(query2), dbm.SQLConnection());

            return View(pav);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}