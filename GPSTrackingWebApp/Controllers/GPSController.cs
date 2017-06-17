using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using GPSTrackingWebApp.Filters;
using GPSTrackingWebApp.Models;

using CaptchaMvc.HtmlHelpers;


namespace GPSTrackingWebApp.Controllers
{
    public class GPSController : Controller
    {
        //
        // GET: /GPS/

        public ActionResult Index()
        {
            return View();
        }

      [HttpPost]
        public ActionResult Index(feedback d )
        {
            mygpsEntities2 db = new mygpsEntities2();
            db.feedbacks.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index","GPS");
            return View();
         
        }


      public ActionResult Email()
      {
          return View();
      }

        [HttpPost]

      public ActionResult Email(String TextBox1, String TextBox2, String TextBox3, String TextBox4)
      {
          MailAddress from = new MailAddress(TextBox1);
          MailAddress to = new MailAddress(TextBox2);
          MailMessage msg = new MailMessage(from, to);
          msg.Subject = TextBox3;
          msg.Body ="Message From:" + TextBox1 +" " + TextBox4;
          //Attachment ob = new Attachment(FileUpload1.FileName);
          //msg.Attachments.Add(ob);
          var cr = new NetworkCredential("gpstracking96@gmail.com", "@GPS12345");
          SmtpClient smt = new SmtpClient("smtp.gmail.com", 587);
          smt.EnableSsl = true;
          smt.Credentials = cr;
          smt.Send(msg);
          ViewBag.Message = "Your query has been sent...";
          return View();

      }

        public ActionResult ForgetPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPass(login k, String TextBox11, String TextBox12, String password, String email)
        {
            try
            {
                mygpsEntities2 db = new mygpsEntities2();
                login p = db.logins.Find(k.sno);
                if (p.sno == k.sno && p.email == k.email)
                {
                    p.password = k.password;
                    db.SaveChanges();
                    ViewBag.Message = "Your Password has been changed ??Please check your gmail";


                    MailAddress from = new MailAddress(TextBox11);
                    MailAddress to = new MailAddress(email);
                    MailMessage msg = new MailMessage(from, to);
                    msg.Subject = TextBox12;
                    msg.Body = "Your password has been Reset:" + " " + " & Your New Password Is: " + password;
                    var cr = new NetworkCredential("gpstracking96@gmail.com", "@GPS12345");
                    SmtpClient smt = new SmtpClient("smtp.gmail.com", 587);
                    smt.EnableSsl = true;
                    smt.Credentials = cr;
                    smt.Send(msg);
                }
                else
                {
                    ViewBag.Message = "Sorry User ID & Password did not matched ??  Please Try Again";

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry User ID & Password did not matched??Please Try Again";
                return View();
            }

            return View();
        }


        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Pricing()
        {
            return View();
        }
        public ActionResult GPSTracking()
        {
            return View();
        }



        public ActionResult login()
        {
            return View();
        }
        [HttpPost]

        
        
        public ActionResult login(login d)
        
        {
            
            mygpsEntities2 db = new mygpsEntities2();
            login k = db.logins.Find(d.sno);
            if (k != null && k.password.Equals(d.password))
            {

                if (Session["id"] != null && Session["email"] != null)
                {
                    return RedirectToAction("Index", "AdminPanel");
                }

        

                ViewBag.Message = "Sucessfully Login:";
                Session["id"] = k.sno.ToString();
                Session["email"] = k.email.ToString();
                return RedirectToAction("Index", "AdminPanel");




            }
            else
            {
                ViewBag.Message = "Sorry Userid & Password not matched";
                return View();
            }



        }


        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            Session["id"] = null;
            Session["email"] = null;
            return RedirectToAction("Index", "GPS");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1000;
            Response.CacheControl = "no-cache";     
         }


    }
}

