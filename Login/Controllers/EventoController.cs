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
                ModelState.AddModelError("Error al agregar el evento", ex);
                return View();
            }
        }
        public ActionResult DetalleEvento(int Id)
        {
            using (EventoContext db = new EventoContext())
            {
               
                return View(db.Lugar.Find(Id).ToList());
            }
        }
    }

}