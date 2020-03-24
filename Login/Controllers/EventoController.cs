﻿using Login.Datos;
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
                ModelState.AddModelError("","Error al agregar el evento"+ex.Message);
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
            }catch(Exception ex)
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
       
    }

}