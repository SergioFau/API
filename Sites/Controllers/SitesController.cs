using System;
using AA_API.Sites.Models;
using AA_API.Sites.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AA_API.Sites.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SitesController : ControllerBase
    {
      
        private readonly ILogger<SitesController> _logger;
        private readonly SitesInfraestructure repositorio;

        public SitesController(ILogger<SitesController> logger)
        {
            _logger = logger;
            repositorio = new SitesInfraestructure();
        }

        [HttpGet (Name = "GetSites")]
        public ActionResult<Site> Get(){
        return Ok(repositorio.getAll());
        }

        [HttpGet ("{id}", Name = "GetSite")]
        public ActionResult<Site> Get(int id){
        Site sitio = repositorio.get(id);
        return sitio != null ? Ok(sitio) : NotFound("No se ha encontrado ese sitio");
        }

        [HttpPost (Name = "CreateSite")]
        public ActionResult<Site> Post([FromBody] Site sitioInsertar){
        Site sitio = repositorio.get(sitioInsertar.id);
        if(sitioInsertar!= null){
            return Conflict("Ya existe un sitio con ese nombre amigo mio");
        }else{
           int numeroContar = repositorio.contar();
           sitioInsertar.id = numeroContar + 1;
           repositorio.add(sitioInsertar);
           String url = Request.Path.ToString() + "/" + sitioInsertar.id;
           return Created(url, sitioInsertar);
        }
        }
        
        [HttpPut (Name = "PutSite")]
        public ActionResult<Site> Put([FromBody] Site sitioRecibida){
        Site sitioCambiar = repositorio.get(sitioRecibida.id);        
        sitioCambiar.nombre = sitioRecibida.nombre;
        sitioCambiar.user = sitioRecibida.user;
        sitioCambiar.createdAt = sitioRecibida.createdAt;
        sitioCambiar.password = sitioRecibida.password;
        sitioCambiar.description = sitioRecibida.description;
        sitioCambiar.idCategory = sitioRecibida.idCategory;
        return Ok("Sitio cambiado");
        }
        
        [HttpDelete ("{id}", Name = "DeleteSite")]
        public ActionResult<Site> Delete(int id){
        Site sitioEliminar = repositorio.get(id);        
        return Ok("Sitio eliminado");
        }
    }
}
