using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.SqlClient;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace GPSTrackingWebApp.Controllers
{
    public class AdminPanelController : Controller
    {
        //
        // GET: /AdminPanel/

        public ActionResult Index()
        {
            if(Session["id"]==null && Session["email"]==null) 
            {

                return RedirectToAction("Index", "GPS");
               
                
            }
            
            return View();
        }

        public ActionResult History()
        {
            return View();
        }
        
        public ActionResult Filter(DateTime pdate)
        {
            ViewBag.Message = pdate + "";
            return PartialView("_dateshow");
        }


        public ActionResult Contacts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contacts(persontracking f)
        {
            try
            {
                mygpsEntities2 db = new mygpsEntities2();
                persontracking  q = db.persontrackings.Find(f.sno);
                q.contact = f.contact;
                q.rcontact1 = f.rcontact1;
                q.rcontact2 = f.rcontact2;
                q.rcontact3 = f.rcontact3;
                q.rcontact4 = f.rcontact4;
                db.SaveChanges();
                ViewBag.Message = "Your Contact Successfully Updated";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry You have entered wrong password??? Please try again";
                return View();
            }
        }




        public ActionResult Renew()
        {
            return View();
        }
        public ActionResult Alert()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(feedback d)
        {
            mygpsEntities2 db = new mygpsEntities2();
            db.feedbacks.Add(d);
            db.SaveChanges();
            ViewBag.Message = " Thank You For Your Feedback";
            return View();

        }





        public ActionResult Logout()
        {
            return View();
        }



        public ActionResult CurrentLoc()
        {
            return View();
        }



        public ActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditProfile(persontracking h)
        {
            try
            {
                mygpsEntities2 dbs = new mygpsEntities2();
                persontracking i = dbs.persontrackings.Find(h.sno);
                i.pid = h.pid;
                i.pname = h.pname;
                i.contact = h.contact;
                i.rcontact1 = h.rcontact1;
                i.rcontact2 = h.rcontact2;
                i.rcontact3 = h.rcontact3;
                i.rcontact4 = h.rcontact4;
                dbs.SaveChanges();
                ViewBag.Message = "Successfully  Profile Updated";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry??? Please try again";
                return View();
            }


        }







        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(login k, String TextBox11, String TextBox12, String password, String email)
        {


            mygpsEntities2 db = new mygpsEntities2();
            login p = db.logins.Find(k.sno);
            if (p.email == k.email)
            {
                p.password = k.password;
                db.SaveChanges();
                ViewBag.Message = "Successfully Password Change";


                MailAddress from = new MailAddress(TextBox11);
                MailAddress to = new MailAddress(email);
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = TextBox12;
                msg.Body = "Your password has been successfully changed:" + " " + " & Your New Password Is: " + password;
                var cr = new NetworkCredential("gpstracking96@gmail.com", "@GPS12345");
                SmtpClient smt = new SmtpClient("smtp.gmail.com", 587);
                smt.EnableSsl = true;
                smt.Credentials = cr;
                smt.Send(msg);
            }
            else
            {
                ViewBag.Message = "Incorrect";

            }

            return View();
        }


        public ActionResult LongLat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LongLat(personallonglat mm)
        {
            mygpsEntities2 db = new mygpsEntities2();
            db.personallonglats.Add(mm);
            db.SaveChanges();
            return RedirectToAction("History","AdminPanel");
        }
        
        public ActionResult ManageAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManageAccount(login f)
        {
            try
            {
                mygpsEntities2 db = new mygpsEntities2();
                login p = db.logins.Find(f.sno);
                    db.logins.Remove(p);
                    db.SaveChanges();
                    ViewBag.Message = "Your Account has been successfully removed";
                    return RedirectToAction("Index", "GPS");
                    return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry You have entered wrong userid??? Please try again";
                return View();
            }
        }



        public ActionResult ShowMap()
        {
            return View();
        }


    




        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(personallonglat k)
        {
            try
            {
             mygpsEntities2 db = new mygpsEntities2();
             personallonglat p = db.personallonglats.Find(k.sno);
                p.pid = k.pid;
                p.pdate = k.pdate;
                p.ptime = k.ptime;
                p.longitude = k.longitude;
                p.lattitude = k.lattitude;
                db.SaveChanges();
                ViewBag.Message = "Successfully Updated";
                RedirectToAction("AdminPanel", "Update");
                return View();
            }
             catch (Exception ex)
                {
                    ViewBag.Message = "Sorry You have entered wrong sno??? Please try again";
                    return View();
                } 

               
        }



        public ActionResult ProfilePic()
        {
            return View();
        }
        [HttpPost]

        public ActionResult ProfilePic(persontracking g, HttpPostedFileBase pimg)
        {
            string path1 = null;
            try
            {
                mygpsEntities2 dbs = new mygpsEntities2();
                persontracking i = dbs.persontrackings.Find(g.sno);

                //  var model = db.people.Find(h.pid);
                string oldfilePath = i.pimg;
                if (pimg != null && pimg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pimg.FileName);
                    string path = Path.Combine(Server.MapPath("../data/"), fileName);
                    pimg.SaveAs(path);
                    path1 = "../data/" + pimg.FileName;
                    string fullPath = Request.MapPath(oldfilePath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }

                i.pimg = path1;
                dbs.SaveChanges();
                ViewBag.Message = "Successfully  Profile pic Uploaded";
                return RedirectToAction("Index","AdminPanel");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Sorry??? Please try again";
                return View();
            }

        }




        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ContactUs(String TextBox1, String TextBox2, String TextBox3, String TextBox4)
        {
            MailAddress from = new MailAddress(TextBox1);
            MailAddress to = new MailAddress(TextBox2);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = TextBox3;
            msg.Body = "Message From:" + TextBox1 + " " + TextBox4;
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






        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int sno)
        {
            try
            {
                mygpsEntities2 db = new mygpsEntities2();
                personallonglat p = db.personallonglats.Find(sno);
                db.personallonglats.Remove(p);
                db.SaveChanges();
                return RedirectToAction("History", "AdminPanel");
        
                             
            }
                       

            catch (Exception ex)
            {
                return View();
            }


        }
       
             
       
    }
}


 
