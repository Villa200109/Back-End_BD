using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Back_End_BD.Controllers
{
    public class MaestrosController : Controller
    {
        public ActionResult Index()
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.ToList());
            }

        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                Maestros alumno = dbMaestros.Maestros.Find(id);
                if (alumno == null)
                {
                    return HttpNotFound();
                }
                return View(alumno);
            }

        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]

        public ActionResult Create(Maestros maes)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                dbMaestros.Maestros.Add(maes);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Edit(Maestros maes)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                dbMaestros.Entry(maes).State = EntityState.Modified;
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Delete(Maestros maes, int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                Maestros al = dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault();
                dbMaestros.Maestros.Remove(al);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}