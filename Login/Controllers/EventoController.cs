using Login.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Login.Controllers
{
    public class EventoController : Controller
    {

        // GET: Evento
        public ActionResult Evento()
        {
            using (EventoContext db = new EventoContext())
            {
                return View(db.Lugar.ToList());
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
        public ActionResult DetalleEvento(int Id)
        {
            using (EventoContext db = new EventoContext())
            {
               
                return View(db.Lugar.Find(Id));
            }
        }
        public ActionResult Editar(int Id)
        {
            using (var db = new EventoContext())
            {
                return View(db.Lugar.Find(Id));
            }
            
        }

        [HttpPost]
        public ActionResult Editar(Lugar a)
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
        public ActionResult Eliminar(int Id)
        {
            using (var db = new EventoContext())
            {
                db.Lugar.Remove(db.Lugar.Find(Id));
               // db.Lugar.remove(db.Tabla.Find(Id));
                db.SaveChanges();
                return RedirectToAction("Evento");
            }

        }
    }

}