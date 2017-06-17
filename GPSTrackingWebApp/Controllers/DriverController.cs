using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace GPSTrackingWebApp.Controllers
{
    public class DriverController : Controller
    {
        //
        // GET: /Driver/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DriverTracking()
        {
            return View();
        }
        public ActionResult Driver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Driver( String sno, String driverid, String drivername, String email, String password, String cpassword, String vehicleno, HttpPostedFileBase driverimg)
        {
            string path1 = null;
            if (driverimg != null && driverimg.ContentLength > 0)
            {
                try
                {

                    string path = Path.Combine(Server.MapPath("~/data"), Path.GetFileName(driverimg.FileName));
                     driverimg.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    path1 = "../data/" +driverimg.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
                mygpsEntities2 db = new mygpsEntities2();
                driver k = new driver();
                k.driverid = driverid;
                k.drivername = drivername;
                k.email = email;
                k.password = password;
                k.cpassword = cpassword;
                k.vehicleno = vehicleno;
                k.driverimg = path1;
                db.drivers.Add(k);
                db.SaveChanges();

                mygpsEntities2 dp = new mygpsEntities2();
                login d = new login();
                d.email = email;
                d.password = password;
                d.type = "driver";
                d.activation = "false";
                dp.logins.Add(d);
                dp.SaveChanges();


            }

            ViewBag.Message = "You have successfully registered.....";
            return View();
        }

    }
}
