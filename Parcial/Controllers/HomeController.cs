using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            ViewBag.Productos = productos;
            return View();
        }

        public ActionResult Carrito()
        {
            ViewBag.Carritos = carritos;
            return View();
        }

        //Lista de Productos
        public static List<string[]> productos = new List<string[]>
        {
            new string [] {"1", "Sombrero", "Textil (Moda)", "Sombrero de cuero", "130.00"},
            new string [] {"2", "Dona", "PGC (Productos de Gran Consumo)", "Dona de chocolate", "25.00"},
        };

        //Lista del Carrito
        public static List<string[]> carritos = new List<string[]>();


        //Agregar producto
        [HttpPost]
        public ActionResult AgregarProducto(string id, string producto, string categoria, string descripcion, string precio)
        {
            productos.Add(new string[] { id, producto, categoria, descripcion, precio });
            return RedirectToAction("Lista");
        }


        //Agregar al carrito
        [HttpPost]
        public ActionResult AgregarCarrito(int indice)
        {
            if (indice >= 0 && indice < productos.Count)
            {
                carritos.Add(productos[indice]);
            }

            return RedirectToAction("Carrito");
        }


        //Eliminar del carrito
        [HttpPost]
        public ActionResult EliminarCarrito(int indice)
        {
            if (indice >= 0 && indice < carritos.Count)
            {
                carritos.RemoveAt(indice);
            }

            return RedirectToAction("Carrito");
        }


        //Eliminar producto
        [HttpPost]
        public ActionResult EliminarProducto(int indice)
        {
            if (indice >= 0 && indice < productos.Count)
            {
                productos.RemoveAt(indice);
            }

            return RedirectToAction("Lista");
        }
    }
}