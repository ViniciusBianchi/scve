using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCVE.Controllers
{
    public class CandidatoController : Controller
    {
        // GET: Candidato
        public ActionResult Index()
        {
            return View();
        }

        // GET: Candidato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidato/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
