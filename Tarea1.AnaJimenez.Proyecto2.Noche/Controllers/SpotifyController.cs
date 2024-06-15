using Microsoft.AspNetCore.Mvc;

namespace Tarea1.AnaJimenez.Proyecto2.Noche.Controllers
{
    //CODIGO DE REFERENCIA, REEMPLAZAR INFO
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ExternalApiService _externalApiService;

        public DataController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        [HttpGet("{param}")]
        public async Task<IActionResult> GetData(string param)
        {
            var data = await _externalApiService.GetApiDataAsync(param);
            return Ok(data);
        }
    }
}
