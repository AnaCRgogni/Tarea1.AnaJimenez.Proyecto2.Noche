using Microsoft.AspNetCore.Mvc;
using BL.Services;

namespace API.Controllers
{
    //ApiController es responsable de manejar solicitudes HTTP entrantes y devolver respuestas HTTP
    //Coordina flujo de datos entre la capa de presentaci�n y la de negocios
    //Tiene los endpoints, llama a servicios de capa de negocios para procesar datos
    //Los DAO tienen interacci�n directa con la base de datos o cualquier otra fuente de datos

    //11 marca clase como un controlador de API que proporciona funcionalidades adicionales
    [ApiController]
    //Define ruta del controlador pictures
    [Route("api/[controller]")]
    public class PicturesController : ControllerBase
    {
        //Declara instancia para almacenar la instancia del servicio de picturenes
        private readonly PictureService _pictureService;

        //Inyeccion de dependencia. Constructor toma una instancia de PictureService y la asigna a _pictureService.
        //As� se proporciona el servicio necesario.
        public PicturesController(PictureService pictureService)
        {
            _pictureService = pictureService;
        }

        //Endpoint de b�squeda de im�genes en la ruta api/pictures/search
        [HttpGet("search")]
        //La interfaz de ActionResult es m�s flexible para cuando se tiene un custom return type
        public async Task<IActionResult> SearchPictures(string query)
        {
            //Verificar que el query no est� vac�o, c�digo 400
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search parameter is empty.");
            }

            //llama al m�todo dentro del servicio de im�genes que tiene la respuesta que busca el endpoint y le pasa el par�metro que ocupa
            var pictures = await _pictureService.SearchPicturesAsync(query);
            //Devuelve la respuesta junto con un c�digo de estado 200
            return Ok(pictures);
        }
    }
}