using System;
using Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    public class DbProducto : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public DbProducto(DbContextOptions<DbProducto> options)
            : base(options)
        {

        }

        public Producto GetbyCodigoProducto(string codigoproducto)
        {
            Producto producto = this
                .Producto
                .FirstOrDefault(c => c.codproducto == codigoproducto);
            return producto;

        }

        public Producto Create(Producto producto)
        {
            try
            {
                this.Producto
                    .Add(producto);

                this.SaveChanges();

                return producto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Producto Update(string codigoproducto,Producto producto)
        {
            try
            {
                var todo = this
                           .Producto
                           .FirstOrDefault(c => c.codproducto == codigoproducto);
                if (todo == null)
                {
                    return null;
                }
                todo.codproducto = producto.codproducto;
                todo.nombreproducto = producto.nombreproducto;
                todo.tipoproducto = producto.tipoproducto;
                todo.saldominimo = producto.saldominimo;
                todo.estado = producto.estado;
                this.Producto
                    .Update(todo);

                this.SaveChanges();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Producto Delete(string codigoproducto)
        {
            try
            {
                var producto = this.GetbyCodigoProducto(codigoproducto);
                if(producto == null)
                {
                    return null;
                }

                this
                    .Producto
                    .Remove(producto);

                this.SaveChanges();

                return producto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }



}
