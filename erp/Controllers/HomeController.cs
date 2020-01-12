using app.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static erp.MvcApplication;

namespace erp.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserInfoService userInfoService;
        public HomeController(IUserInfoService userInfoService
           )
        {
            this.userInfoService = userInfoService;            
        }
        int user;
        public ActionResult Index()
        {
            user = 1;
            var userInfo = userInfoService.GetUserById(user);
            Sessions.UserId = userInfo.Id;
            Sessions.InstituteId = userInfo.InstituteId;
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Dashboard()
        {
            return PartialView();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
        public ActionResult Navigation()
        {
            return PartialView();
           }
        }
}