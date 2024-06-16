using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PictureController : Controller
    {
        //Procesa las solicitudes del cliente y devuelve los datos necesarios
        public async Task<IActionResult> SearchPictures(string query)
        {
            var pictures = await _pictureService.SearchPicturesAsync(query);
            if (pictures == null || !pictures.Any())
            {
                return NotFound("No pictures were found.");
            }

            return Ok(pictures);
        }
    }
}