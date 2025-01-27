using Microsoft.AspNetCore.Mvc;
using PruebaNET.Services;
using PRUEBANET.Models;

namespace PRUEBANET.Controller {

    [Route("api")]
    [ApiController]
    public class ServiciosContablesController : ControllerBase
    {
        private readonly ServiciosContablesService _serviciosContablesServices;

        public ServiciosContablesController(ServiciosContablesService serviciosContablesServices)
        {
            _serviciosContablesServices = serviciosContablesServices;
        }

      

        [HttpGet("contabilidad/registros")]
        public async Task<ActionResult<List<RegistrosContablesAORRALA>>> TodosRegistrosContables()
        {
            var activeUsers = await _serviciosContablesServices.TodosRegistrosContables();
            return Ok(activeUsers);
        }

        [HttpGet("/banco/movimientos")]
        public async Task<ActionResult<List<RegistrosContablesAORRALA>>> TodosmovimientosContables()
        {
            var activeUsers = await _serviciosContablesServices.TodosmovimientosContables();
            return Ok(activeUsers);
        }

        [HttpPost("/api/conciliacion")]
        public async Task<ActionResult<List<DiscrepanciasAORRALA>>> Concileacion([FromBody] EntradaConcileacion Body)
        {
            var concileaciones = await _serviciosContablesServices.Concileacion(Body);
            return concileaciones;
        }       
    }
        
}
