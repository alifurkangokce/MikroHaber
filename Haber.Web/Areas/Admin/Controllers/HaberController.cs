﻿using Haber.Model;
using Haber.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Haber.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize]
    public class HaberController : Controller
    {
        public string GenerateSlug(string phrase)
        {
            string str = phrase.ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private readonly IHaberService haberService;
        public HaberController(IHaberService haberService)
        {
            this.haberService = haberService;
        }


        // GET: Admin/Haber
        public ActionResult Index()
        {

            var haberler = haberService.GetAll();

            return View(haberler);

        }

        public ActionResult Create()
        {
            var Haber = new Haberler();
            
            return View(Haber);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Haberler Haber,HttpPostedFileBase upload)
        {
        
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        var photoname = Haber.HaberBaslik;
                        fileName = photoname + extension;
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        Haber.HaberPhoto= fileName;
                        Haber.Slug = GenerateSlug(Haber.HaberBaslik);
                        haberService.Insert(Haber);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");
                    }
                }
                else
                {
                    haberService.Insert(Haber);
                    return RedirectToAction("index");
                }

            }
            
            return View(Haber);

        }
        public ActionResult Edit(Guid id)
        {
            var haber = haberService.Find(id);
            if (haber == null)
            {
                return HttpNotFound();

            }
            return View(haber);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Haberler haber, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var model = haberService.Find(haber.Id);
                if (upload != null && upload.ContentLength > 0)
                {
                    
                    string fileName = Path.GetFileName(upload.FileName);
                    string extension = Path.GetExtension(fileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["uploadPath"], fileName);
                        upload.SaveAs(path);
                        haber.HaberPhoto = fileName;
                        haberService.Update(haber);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Photo", "Dosya uzantısı .jpg, .jpeg, .png ya da .gif olmalıdır.");

                    }
                }
                else
                {
                    // resim seçilip yüklenmese bile diğer bilgileri güncelle
                    haberService.Update(haber);
                    return RedirectToAction("index");
                }            
            }

            return View(haber);
        }
        public ActionResult Delete(Guid id)
        {
            haberService.Delete(id);
            return RedirectToAction("index");

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