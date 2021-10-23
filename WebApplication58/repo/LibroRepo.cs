using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication58.Models;

namespace WebApplication58.repo
{
    public class LibroRepo
    {
        public void Insertar(Libro libro)
        {
            //todo: pendiente.
        }
        public int StockTotalV1()
        {
            var libros=Listar();
            int total=0;
            foreach(var libro in libros) { 
                total=total+libro.Stock;   
            }
            return total;
        }
        public int StockTotalV2()
        {
            var libros = Listar();
            int total = libros.Sum( li => li.Stock);
            return total;
        }
        // mockup
        public Libro Obtener(int id)
        {
            // todo: pendiente
            return new Libro { Id=id,Titulo="ficticio "+id,Stock=1};
        }
        public void AumentarStock(int id,int cantidad)
        {
            var libro=Obtener(id);
            libro.Stock=libro.Stock+cantidad;
            Actualizar(libro);
        }

        public void Actualizar(Libro libro)
        {
            //todo:
        }
        public List<Libro> Listar()
        {
            var listar=new List<Libro>();
            listar.Add(new Libro { Id = 1, Titulo = "ficticio 1", Stock = 3 });
            listar.Add(new Libro { Id = 2, Titulo = "ficticio 2", Stock = 3 });
            return listar;
        }
        public int ObtenerStock(int id)
        {
            return Obtener(id).Stock;
        }
        public bool Venta(int id)
        {
            // vender el libro 5.
            var libro=Obtener(id);
            // revisar el stock
            if(ObtenerStock(id)<=0)
            {
                // no hay stock
                return false;
            }
            // como hay stock
            // registrar la venta.
            // insertar una venta.
            libro.Stock=libro.Stock-1;
            Actualizar(libro); // reducir el stock
            return true;
        }

    }
}
