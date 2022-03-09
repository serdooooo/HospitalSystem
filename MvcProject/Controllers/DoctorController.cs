using MvcProject.Models;
using MvcProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        DoctorRepository repo = new DoctorRepository();
        public ActionResult Index()
        {
            var lst = repo.List();
            return View(lst);
        }
        public ActionResult DoctorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorAdd(Doctor d)
        {
            repo.TAdd(d);
            return RedirectToAction("Index");
        }
        public ActionResult DoctorDelete(int id)
        {
            Doctor d = repo.Find(x => x.ID == id);
            repo.TDelete(d);
            return RedirectToAction("Index");
        }
    }
}