using Microsoft.AspNetCore.Mvc;
using SessionConObjetos.Extensions;
using SessionConObjetos.Models;
using SessionConObjetos.Repositories;

namespace SessionConObjetos.Controllers
{
    public class RestauranteController : Controller
    {
        private RepositoryRestaurantes repo;
        public RestauranteController(RepositoryRestaurantes repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Restaurante> restaurantesTotal = this.repo.GetRestaurantes();
            return View(restaurantesTotal);
        }

        public IActionResult GuardarSession(int idrest)
        {
            if (idrest != null)
            {
                Restaurante restaurante = this.repo.FindRestaurante(idrest);
                List<Restaurante> restaurantesSession;
                if (HttpContext.Session.GetObject<List<Restaurante>>("ListaObjetos") != null)
                {
                    restaurantesSession = HttpContext.Session.GetObject<List<Restaurante>>("ListaObjetos");
                }
                else
                {
                    restaurantesSession = new List<Restaurante>();
                }
                restaurantesSession.Add(restaurante);
                HttpContext.Session.SetObject("ListaObjetos", restaurantesSession);
            }
          
            return RedirectToAction("Index");

        }

        public IActionResult RestaurantesAlmacenados()
        {
            return View();
        }
    }
}
