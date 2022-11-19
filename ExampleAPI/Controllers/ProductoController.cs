using ExampleAPI.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoController()
        {

        }
        [HttpGet]
        public ActionResult<List<ProductoResponse>> GetAll()
        {
            var products = GetProductos();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<ProductoResponse> Get(int id)
        {
            var products = GetProductos();
            var filter = products.Find(x => x.IdProducto == id);
            return Ok(filter);
        }
        [HttpDelete("{id}")]
        public ActionResult<ProductoResponse> Delete(int id)
        {
            var products = GetProductos();
            var filter = products.FindAll(x => x.IdProducto != id);
            return Ok(filter);
        }
        [HttpPost]
        public ActionResult<ProductoResponse> CreateProducto([FromBody] ProductoResponse producto)
        {
            var products = GetProductos();
            producto.IdProducto = products.Count + 1;
            products.Add(producto);
            return Ok(products);
        }
        [HttpPut("{id}")]
        public ActionResult<ProductoResponse> Update(int id, [FromBody] ProductoResponse producto)
        {
            var products = GetProductos();
            var filter = products.Find(x => x.IdProducto == id);
            if (filter != null)
            {
                filter.NombreProducto = producto.NombreProducto;
                filter.Estado = producto.Estado;
            }
            return Ok(filter);
        }

        private static List<ProductoResponse> GetProductos()
        {
            var products = new List<ProductoResponse>()
            {
                new ProductoResponse { IdProducto= 1, NombreProducto = "Producto 1", Estado = true },
                new ProductoResponse { IdProducto= 2, NombreProducto = "Producto 2", Estado = true },
                new ProductoResponse { IdProducto= 3, NombreProducto = "Producto 3", Estado = true },
                new ProductoResponse { IdProducto= 4, NombreProducto = "Producto 4", Estado = true },
                new ProductoResponse { IdProducto= 5, NombreProducto = "Producto 5", Estado = true }
            };
            return products;
        }
    }
}
