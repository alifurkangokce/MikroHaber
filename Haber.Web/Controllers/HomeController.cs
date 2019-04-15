using Haber.Service;
using log4net;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haber.Web.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController)); //type of class



        private readonly IHaberService haberService;
        public HomeController(IHaberService haberService)
        {
            this.haberService = haberService;
        }
        public ActionResult Index(int? page)
        {
            log.Debug("Debug message");

            log.Warn("Warn message");

            log.Error("Error message");

            log.Fatal("Fatal message");

            ViewBag.haberler = haberService.GetAll();
            //var haberler = haberService.GetAll();
            var pageNumber = page ?? 1;
            var haberler = this.haberService.GetAll().Where(f => f.IsActive == true).OrderBy(f => f.HaberSirano);
            var onePageOfPosts = haberler.ToPagedList(pageNumber, 2);

            

            return View(onePageOfPosts);

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(string Slug)
        {
            var haber = haberService.Find(Slug);
            if (haber == null)
            {
                return HttpNotFound();

            }

            return View(haber);
        }
    }
}