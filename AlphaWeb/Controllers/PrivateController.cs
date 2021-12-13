using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.WebModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAlpha.Controllers
{
    public class PrivateController : Controller
    {
        BusinessController bc = new BusinessController();
        Guid userID = Guid.Empty;
        bool access = false;

        public void CheckLogin()
        {
            //Check login ToDo use access token to get access
            if (HttpContext.Session != null)
            {
                string value = HttpContext.Session.GetString("UserID");

                if (value != null && value != string.Empty)
                {
                    userID = Guid.Parse(value);
                    access = true;
                }
            }            
        }

      
        public ActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Login(User input)
        {
            User user = bc.GetUserByLogin(input.UserName, input.Password);
            
            if (user != null)
            {
                HttpContext.Session.SetString("UserID", user.UserID.ToString());
                return RedirectToAction("Index", "private");
            }

            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.SetString("UserID", string.Empty);
            return RedirectToAction("Login", "private");
        }

        // GET: PrivateController
        public ActionResult Index()
        {
            CheckLogin();           
            if (access == false)
            {
                return RedirectToAction("Login", "private");
            }

            User user = bc.GetUserByID(userID);
            return View(user);
        }


        public ActionResult CreateReview(Guid id)
        {
            CheckLogin();
            if (access == false)
            {
                return RedirectToAction("Login", "private");
            }

            Company company = bc.GetCompanyById(id);
            
            if (company != null)
            {
                Review model = new Review()
                {
                    CompanyID = id
                };
                return View(model);
            }
            return RedirectToAction("Index", "public");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReview(Review input)
        {
            CheckLogin();
            if (access == false)
            {
                return RedirectToAction("Login", "private");
            }

            input.UserID = userID;
            input.Timestamp = DateTime.Now;
            input.ReviewID = Guid.NewGuid();
            bc.ReviewCreate(input);

            return RedirectToAction("ShowCompany", "public", new { id = input.CompanyID });
        }

         public ActionResult UserEdit()
         {
            CheckLogin();
            if (access == false)
            {
                return RedirectToAction("Login", "private");
            }

            User model = bc.GetUserByID(userID);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserEdit(User input)
        {
            CheckLogin();
            if (access == false)
            {
                return RedirectToAction("Login", "private");
            }

            bc.UserUpdate(input);

            return RedirectToAction("Index", "private");
        }
        
    }
}
