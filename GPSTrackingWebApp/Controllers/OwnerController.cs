using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.SqlClient;
namespace GPSTrackingWebApp.Controllers
{
    public class OwnerController : Controller
    {
        //
        // GET: /Owner/

        public ActionResult Owner()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OwnerTracking()
        {
            return View();
        }
    [HttpPost]
        public ActionResult Owner(String sno, String ownerid, String ownername, String email, String password, String confirmpassword, String contactno, String vehicleno, HttpPostedFileBase ownerpic)
        {
            string path1 = null;
            if (ownerpic != null && ownerpic.ContentLength > 0)
            {
                try
                {

                    string path = Path.Combine(Server.MapPath("~/data"), Path.GetFileName(ownerpic.FileName));
                    ownerpic.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    path1 = "../data/" + ownerpic.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
                mygpsEntities2 db = new mygpsEntities2();
                ownertracking k = new ownertracking();
                k.ownerid = ownerid;
                k.ownername = ownername;
                k.email = email;
                k.password = password;
                k.confirmpassword = confirmpassword;
                k.contactno = contactno;
                k.vehicleno = vehicleno;
                k.ownerpic = path1;
                db.ownertrackings.Add(k);
                db.SaveChanges();


                mygpsEntities2 dp = new mygpsEntities2();
                login d = new login();
                d.email = email;
                d.password = password;
                d.type = "ownertracking";
                d.activation = "false";
                dp.logins.Add(d);
                dp.SaveChanges();


            }

            ViewBag.Message = "You have successfully registered.....";
            return View();
        }

    }
}
