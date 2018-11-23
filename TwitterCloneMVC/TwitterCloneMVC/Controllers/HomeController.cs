using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TwitterCloneMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Person login)
        {
            if (ModelState.IsValid)
            {
                TwitterCloneEntities db = new TwitterCloneEntities();
                var user = (from userlist in db.People
                            where userlist.User_id == login.User_id && userlist.password == login.password
                            select new
                            {
                                userlist.User_id,
                                userlist.password
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().User_id;
                    Session["Password"] = user.FirstOrDefault().password;
                    //string username = User.Identity.Name= user.FirstOrDefault().User_id;
                    return RedirectToAction("Index", "TWEETs");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }



        [AllowAnonymous]
        public ActionResult SignUp()
        {
            //ViewBag.Message = "Your application description page.";

            return this.View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(Person obj)
        {
            //ViewBag.Message = "Your application description page.";
            TwitterCloneEntities twitEntityObj = new TwitterCloneEntities();
            twitEntityObj.People.Add(obj);
            twitEntityObj.SaveChanges();
            return this.View();
        }
        public ActionResult userProfile()
        {
            string userName = Session["UserName"].ToString();
            TwitterCloneEntities twitEntityObj = new TwitterCloneEntities();
            var userObj = twitEntityObj.People.Where(s => s.User_id == userName).FirstOrDefault();
            return View(userObj);
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult userProfile(Person obj)
        {
            //ViewBag.Message = "Your application description page.";
            TwitterCloneEntities twitEntityObj = new TwitterCloneEntities();
            //twitEntityObj.People.Add(obj);

            var userObj = twitEntityObj.People.FirstOrDefault(u => u.User_id.Equals(obj.User_id));

            // Update fields
            userObj.User_id = obj.User_id;
            userObj.fullName = obj.fullName;
            userObj.email = obj.email;
            userObj.active = obj.active;
            userObj.joined = obj.joined;

            twitEntityObj.Entry(userObj).State = EntityState.Modified;
            twitEntityObj.SaveChanges();
            return this.View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return this.RedirectToAction("Index", "Home");
        }

    }
}