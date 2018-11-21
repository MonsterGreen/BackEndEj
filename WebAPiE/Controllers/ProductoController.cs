using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Database;

namespace WebAPiE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DbProducto dbProducto;

        public ProductoController(DbProducto dbProducto)
        {
            this.dbProducto = dbProducto;
        }

        [HttpGet("{codigoproducto}")]
        public IActionResult get(string codigoproducto)
        {
            var producto = this.dbProducto.GetbyCodigoProducto(codigoproducto);

            if (producto == null)
            {
                return BadRequest($"El producto {codigoproducto} no se encuentra registrado");
            }

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            var result = this.dbProducto.Create(producto);
            if (result == null)
            {
                return BadRequest($"No fue posible crear el producto {producto.codproducto}.");
            }

            return Ok(result);
        }


        [HttpDelete("{codigoproducto}")]
        public IActionResult Delete(string codigoproducto)
        {
            var result = this.dbProducto.Delete(codigoproducto);
            if (result == null)
            {
                return BadRequest($"No fue posible eliminar al producto {codigoproducto}.");
            }

            return Ok(result);
        }

    }
}