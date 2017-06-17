using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace GPSTrackingWebApp.Controllers
{
    public class VehicleController : Controller
    {
        //
        // GET: /Vehicle/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult VehicleTracking()
        {
            return View();
        }


        public ActionResult Vehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Vehicle(vehicletracking d)
        {
            mygpsEntities2 db = new mygpsEntities2();
            db.vehicletrackings.Add(d);
            db.SaveChanges();
            ViewBag.Message = "Sucessfully Vehical Registration Done";
            return View();
         }

    }
}
