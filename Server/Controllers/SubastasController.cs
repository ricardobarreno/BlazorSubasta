using System;
using System.Collections.Concurrent;
using System.Linq;
using BlazorSubasta.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSubasta.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubastasController : ControllerBase
    {
        private readonly ConcurrentDictionary<string, Subasta> concurrent;

        public SubastasController(ConcurrentDictionary<string, Subasta> concurrent)
        {
            if (concurrent.Count == 0)
            {
                string[] guids = { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
                
                concurrent.TryAdd(guids[0], new Subasta
                {
                    Id = guids[0],
                    Nombre = "Play Station 5",
                    UrlImagen = "https://mxsonyb2c.vteximg.com.br/arquivos/ids/263350-1000-1000/PS5_Fisica_DS.jpg"
                });

                concurrent.TryAdd(guids[1], new Subasta
                {
                    Id = guids[1],
                    Nombre = "Un nuevo sol",
                    UrlImagen = "https://portal.andina.pe/EDPfotografia3/Thumbnail/2016/01/05/000333634W.jpg"
                });

                concurrent.TryAdd(guids[2], new Subasta
                {
                    Id = guids[2],
                    Nombre = "El guantelete del infinito",
                    UrlImagen = "https://i.pinimg.com/originals/6c/14/53/6c14531bfd36220a91c23d78171094ec.jpg"
                });
            }

            this.concurrent = concurrent;
        }


        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            if (concurrent.Count == 0)
                return NoContent();
            
            return Ok(concurrent.Values);
        }


        [HttpGet("{id}")]
        public IActionResult ObtenerPorId([FromRoute] string id)
        {
            if (!concurrent.ContainsKey(id))
                return NoContent();

            return Ok(concurrent[id]);
        }


    }
}
