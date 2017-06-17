using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Mail;
using System.Net;
using CaptchaMvc.HtmlHelpers;
using System.Web.Security;
using GPSTrackingWebApp.Models;
  

namespace GPSTrackingWebApp.Controllers
{
    public class PersonalController : Controller
    {
        //
        mygpsEntities2 db = new mygpsEntities2();
        // GET: /Personal/
        public ActionResult Captcha()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Personal()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Personal( string Empty, String TextBox6, String TextBox7,  String sno, String pid, String pname, String email, String password, String repassword, String contact,
         String rcontact1, String rcontact2, String rcontact3, String rcontact4, HttpPostedFileBase pimg)
        {
            try
            {

                string path1 = null;
                if (pimg != null && pimg.ContentLength > 0)
                {
                    try
                    {

                        string path = Path.Combine(Server.MapPath("~/data"), Path.GetFileName(pimg.FileName));
                        pimg.SaveAs(path);
                        path1 = "../data/" + pimg.FileName;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }

                    if (this.IsCaptchaValid("Captcha is not valid"))
                    {
                        mygpsEntities2 db = new mygpsEntities2();
                        persontracking k = new persontracking();
                        k.pid = pid;
                        k.pname = pname;
                        k.email = email;
                        k.password = password;
                        k.repassword = repassword;
                        k.contact = contact;
                        k.rcontact1 = rcontact1;
                        k.rcontact2 = rcontact2;
                        k.rcontact3 = rcontact3;
                        k.rcontact4 = rcontact4;
                        k.pimg = path1;
                        db.persontrackings.Add(k);
                        db.SaveChanges();



                        mygpsEntities2 dp = new mygpsEntities2();
                        login d = new login();
                        d.email = email;
                        d.password = password;
                        d.type = "personaltracking";
                        d.activation = "false";
                        dp.logins.Add(d);
                        dp.SaveChanges();
                        ViewBag.Message = "You have successfully registered.....";




                        MailAddress from = new MailAddress(TextBox6);
                        MailAddress to = new MailAddress(email);
                        MailMessage msg = new MailMessage(from, to);
                        msg.Subject = TextBox7;
                        msg.Body = "You have been succesfully registered, Use This UserID and Password For Login.... :" + " " + " " + " " + "Your User ID Is:" + " " + " " + d.sno + "" + " " + " " + " &" + "Your Password Is:" + " " + " " + password;
                        var cr = new NetworkCredential("gpstracking96@gmail.com", "@GPS12345");
                        SmtpClient smt = new SmtpClient("smtp.gmail.com", 587);
                        smt.EnableSsl = true;
                        smt.Credentials = cr;
                        smt.Send(msg);








                    }
                    else
                    {
                        ViewBag.ErrMessage = "Error : captcha is not valid";
                    }







                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Email Already Exist";
                return View();
            }

           
            return View();



        }


      //  [HttpPost]
      //  public JsonResult Personal(String email)
        //{

          //  return Json(!db.persontrackings.Any(x => x.email == email), JsonRequestBehavior.AllowGet);
       // } 
   
       
   
           
            }
        }


        
    

