using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication58.Models;
using WebApplication58.repo;

namespace WebApplication58.Controllers
{
    public class LibroController : Controller
    {
        // campo
        private LibroRepo servicio = new LibroRepo();

        public IActionResult Index()
        {
            
            // 1) leer.
            var libros= servicio.Listar();
            ViewBag.total=servicio.StockTotalV1();
            return View(libros); // @Model va a tener una lista de libros.
        }

        [HttpGet]
        public IActionResult LibroVender(int id)
        {
            
            var libro=servicio.Obtener(id);
            ViewBag.stockdisponible= (int)servicio.ObtenerStock(id);
            ViewBag.libro=libro;
            return View();
        }

        [HttpGet]
        public IActionResult LibroAumento(int id)
        {
            var libro=servicio.Obtener(id);
            return View(libro);
        }

        [HttpPost]
        public IActionResult LibroAumento()
        {
            int id=Convert.ToInt32(Request.Form["id"]);
            int stockadicional = Convert.ToInt32(Request.Form["stockadicional"]);

            servicio.AumentarStock(id,stockadicional);

            // var libro = servicio.Obtener(id);
            return Redirect("/Libro");
        }


        [HttpPost]
        public IActionResult LibroVender()
        {
            // Request
            // Response
            //string idleido=Request.Query["campo1"]; // get
            int id = Convert.ToInt32(Request.Form["campo1"]); // post ("2")
            var resultado=servicio.Venta(id);
            //  resultado=false; // solo para pruebas
            if(resultado)
            {
                // si el libro se vendio, redireccionar al listado
                return Redirect("/libro");
            }
            // si no se pudo vender...
            ViewBag.falla=true;
            var libro = servicio.Obtener(id);
            ViewBag.stockdisponible = (int)servicio.ObtenerStock(id);
            ViewBag.libro=libro;

            return View();
        }

            [HttpGet]
        public IActionResult Insertar()
        {
            var libro = new Libro();
            return View(libro);
        }


        // post es cuando se estan recibiendo datos.
        [HttpPost]
        public IActionResult Insertar(Libro libro)
        {
            // Libro libro=new Libro();
            // libro.Titulo="Hola";
            // libro.Stock=4444;
            return View(libro);
        }

    }
}
