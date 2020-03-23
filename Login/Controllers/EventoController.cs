using Login.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Login.Controllers
{
    public class EventoController : Controller
    {

        // GET: Evento
        public ActionResult Evento()
        {
            try
            {
                using (var  db = new EventoContext())
                {

                return View(db.Lugar.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }     
        }
        public ActionResult TusEventos()
        {
            try
            {
                using (var db = new EventoContext())
                {
                    List<Lugar> lista = db.Lugar.Where(a => a.Usuario == User.Identity.GetUserName()).ToList();
                    return View(lista);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult CrearEvento()
        {
                return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEvento(Lugar a)
        {
            try
            {
                using (var db = new EventoContext())
                {
                    
                    db.Lugar.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Evento");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Error al agregar el evento"+ex.Message);
                return View();
            }
        }

        public ActionResult EditarEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditarEvento(Lugar a)
        {
            try
            {
                using (var db = new EventoContext())
                {

                    db.Entry(db.Lugar.Find(a.ID)).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Evento");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el evento", ex);
                return View();
            }
        }
       
    }

}