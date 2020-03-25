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
                using (var db = new EventoContext())
                {

                    return View(db.Lugar.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al igresar" + ex.Message);
                return View();
            }
        }
        
        public ActionResult EventosAlrededor(double[] coord, int distancia)
        {
            
            try
            {
                using (var db = new EventoContext())
                {
                    List<Lugar> lista=db.Lugar.Where(a=> (Math.Sqrt((Math.Pow ( Double.Parse(a.Latitud) - coord[0],2)) +(Math.Pow ( Double.Parse(a.Longitud) - coord[1],2)))<distancia)).ToList();
                    return View(lista);
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", "Error al consultar" + ex.Message);
                return View();
            }
        }

        public ActionResult EventosGustos(string categoria)
        {
            try
            {
                using (var db = new EventoContext())
                {

                    List<Lugar> lista = db.Lugar.Where(a => a.Categoria == categoria).ToList();
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al igresar" + ex.Message);
                return View();
            }
        }

        public ActionResult TopEventos()
        {
            try
            {
                using (var db = new EventoContext())
                {

                    List<Lugar> lista = db.Lugar.OrderByDescending(a => a.Asistentes).Take(5).ToList();
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al igresar" + ex.Message);
                return View();
            }
        }
        public ActionResult TusEventos()
        {
            try
            {
                using (var db = new EventoContext())
                {
                    String valor = User.Identity.GetUserName();
                    List<Lugar> lista = db.Lugar.Where(a => a.Usuario == valor).ToList();
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al igresar" + ex.Message);
                return View();
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
                    a.Asistentes = 0;
                    a.Usuario = User.Identity.GetUserName();
                    db.Lugar.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("TusEventos");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el evento" + ex.Message);
                return View();
            }
        }

        public ActionResult EditarEvento(int id)
        {
            try
            {
                using (var db = new EventoContext())
                {
                    Lugar evento = db.Lugar.Find(id);
                    return View(evento);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar al evento" + ex.Message);
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEvento(Lugar a)
        {
            try
            {
                using (var db = new EventoContext())
                {
                    Lugar evento = db.Lugar.Find(a.ID);
                    evento.Nombre = a.Nombre;
                    evento.Ubicacion = a.Ubicacion;
                    evento.Latitud = a.Latitud;
                    evento.Longitud = a.Longitud;
                    evento.Categoria = a.Categoria;
                    evento.FechaInicio = a.FechaInicio;
                    evento.FechaFin = a.FechaFin;
                    evento.Capacidad = a.Capacidad;
                    evento.Descripcion = a.Descripcion;
                    db.SaveChanges();
                    return RedirectToAction("TusEventos");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar al evento" + ex.Message);
                return View();
            }
        }

        public ActionResult DetallesEvento(int id)
        {
            try
            {
                using (var db = new EventoContext())
                {
                    Lugar evento = db.Lugar.Find(id);
                    return View(evento);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar al evento" + ex.Message);
                return View();
            }
        }
        public ActionResult EliminarEvento(int id)
        {
            try
            {
                using (var db = new EventoContext())
                {
                    Lugar evento = db.Lugar.Find(id);
                    db.Lugar.Remove(evento);
                    db.SaveChanges();
                    return RedirectToAction("TusEventos");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar al evento" + ex.Message);
                return View();
            }
        }
        public ActionResult Asistir(int id)
        {
            try
            {
                using (var db = new EventoContext())
                {
                    Lugar evento = db.Lugar.Find(id);
                    if (evento.Capacidad >= evento.Asistentes)
                    {
                         evento.Asistentes = evento.Asistentes + 1;
                         db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Nota = "NO PUEDE ASISTIR-CAPACIDAD MAXIMA ";
                    }
                    return RedirectToAction("Evento");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al encontrar al evento" + ex.Message);
                return View("Evento");
            }
        }
    }

}
