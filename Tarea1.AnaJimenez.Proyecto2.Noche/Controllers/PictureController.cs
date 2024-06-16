using Microsoft.AspNetCore.Mvc;
using BL.Services;

namespace API.Controllers
{
    //ApiController es responsable de manejar solicitudes HTTP entrantes y devolver respuestas HTTP
    //Coordina flujo de datos entre la capa de presentación y la de negocios
    //Tiene los endpoints, llama a servicios de capa de negocios para procesar datos
    //Los DAO tienen interacción directa con la base de datos o cualquier otra fuente de datos

    //11 marca clase como un controlador de API que proporciona funcionalidades adicionales
    [ApiController]
    //Define ruta del controlador pictures
    [Route("api/[controller]")]
    public class PicturesController : ControllerBase
    {
        //Declara instancia para almacenar la instancia del servicio de picturenes
        private readonly PictureService _pictureService;

        //Inyeccion de dependencia. Constructor toma una instancia de PictureService y la asigna a _pictureService.
        //Así se proporciona el servicio necesario.
        public PicturesController(PictureService pictureService)
        {
            _pictureService = pictureService;
        }

        //Endpoint de búsqueda de imágenes en la ruta api/pictures/search
        [HttpGet("search")]
        //La interfaz de ActionResult es más flexible para cuando se tiene un custom return type
        public async Task<IActionResult> SearchPictures(string query)
        {
            //Verificar que el query no está vacío, código 400
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search parameter is empty.");
            }

            //llama al método dentro del servicio de imágenes que tiene la respuesta que busca el endpoint y le pasa el parámetro que ocupa
            var pictures = await _pictureService.SearchPicturesAsync(query);
            //Devuelve la respuesta junto con un código de estado 200
            return Ok(pictures);
        }
    }
}