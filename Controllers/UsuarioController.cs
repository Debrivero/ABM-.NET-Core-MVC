using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Examen_tecnico_COA.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ExamenTecnicoCOAContext _context;

        public UsuarioController(ExamenTecnicoCOAContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int IdUsuario)
        {
            try
            {
                ExamenTecnicoCOAContext db = new ExamenTecnicoCOAContext();
                var usuario = new Models.Usuario();
                usuario = db.Usuarios.First(d => d.IdUsuario == IdUsuario);
                db.Remove(usuario);
                db.SaveChanges();

                return Redirect("~/Home/Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Usuario _usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ExamenTecnicoCOAContext db = new ExamenTecnicoCOAContext();
                    var usuario = new Models.Usuario();
                    usuario.UserName = _usuario.UserName;
                    usuario.Name = _usuario.Name;
                    usuario.Email = _usuario.Email;
                    usuario.Telefono = _usuario.Telefono;
                    db.Add(usuario);
                    db.SaveChanges();
                    return Redirect("~/Home/Index");
                }
                return View();

            }

            catch (Exception ex) // Por si hay un error
            {
                throw new Exception(ex.Message);
            }

            // return View();
        }

        public ActionResult Modificar(int IdUsuario)
        {
            var usuarioModel = new Models.Usuario();
            ExamenTecnicoCOAContext db = new ExamenTecnicoCOAContext();
            var usuario = new Models.Usuario();
            usuario = db.Usuarios.First(d => d.IdUsuario == IdUsuario);
            usuarioModel.UserName = usuario.UserName;
            usuarioModel.Name = usuario.Name;
            usuarioModel.Email = usuario.Email;
            usuarioModel.Telefono = usuario.Telefono;


            return View(usuarioModel);
        }

        [HttpPost]
        public ActionResult Modificar(Models.Usuario _usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ExamenTecnicoCOAContext db = new ExamenTecnicoCOAContext();
                    var usuario = new Models.Usuario();
                    usuario = db.Usuarios.First(d => d.IdUsuario == _usuario.IdUsuario);
                    usuario.UserName = _usuario.UserName;
                    usuario.Name = _usuario.Name;
                    usuario.Email = _usuario.Email;
                    usuario.Telefono = _usuario.Telefono;
                    db.Update(usuario);
                    db.SaveChanges();
                    return Redirect("~/Home/Index");

                }
                return View();
            }
            catch (Exception ex) // Por si hay un error
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
