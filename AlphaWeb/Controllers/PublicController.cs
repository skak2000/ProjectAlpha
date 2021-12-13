using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.WebModel;
using System;
using System.Collections.Generic;

namespace WebAlpha.Controllers
{
    public class PublicController : Controller
    {
        BusinessController bc = new BusinessController();
        // GET: PublicController
        public ActionResult Index()
        {
            List<Company> model = bc.GetCompanyList();
            return View(model);
        }

        public ActionResult ShowCompany(Guid id)
        {
            Company model = bc.GetCompanyById(id);
            return View(model);
        }

        public ActionResult ViewProfile(Guid id)
        {
            UserPublic model = bc.GetPublicUserByID(id);
            return View(model);
        }

        public ActionResult UserList()
        {
            List<UserPublic> model = bc.GetAllUsers();
            return View(model);
        }

        public ActionResult Image(Review input)
        {
            string respont = input.Base64String;

            if (input.Base64String == null)
            {
                respont = bc.GetImage("Images\\Burger1.jpg");
            }

            return this.File(respont, "image/jpg", "image.jpg");
        }

        public ActionResult CreateCompany()
        {
            Company model = new Company();
            return View(model);
        }


        [HttpPost]
        public ActionResult CreateCompany(Company input)
        {
            bc.CompanyCreate(input);
            return RedirectToAction("Index", "public");
        }

        public ActionResult CreateUser()
        {
            User model = new User();
            return View(model);
        }


        [HttpPost]
        public ActionResult CreateUser(User input)
        {
            bc.CreateUser(input);
            return RedirectToAction("UserList", "public");
        }
    }
}
