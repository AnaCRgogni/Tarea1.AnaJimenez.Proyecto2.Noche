using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace BL
{
    public class PictureDao
    {
        //Almacena instancia de clase HttpClient para hacer solicitudes HTTP
        //Readonly porque se asigna una vez y no se cambia
        private readonly HttpClient _httpClient;
        //Almacena clave API de Pexels para autenticar las solicitudes a la API
        private readonly string _apiKey = "vEHXAZ1dogstsay4iJc1Vl8T27BjKif4iwSbO06kCepruRSgZPFHMxIk";

        public PictureDao(HttpClient httpClient)
        {
            //_ es convención para variables privadas de instancia. Ayuda a distinguir de parámetros de métodos o variables locales
            _httpClient = httpClient;
        }

        //El query de parámetro es lo que el usuario pone en la vista
        public async Task<List<PictureModel>> SearchPicturesAsync(string query)
        {
            //Esta línea configura los encabezados de la solicitud HTTP para incluir la clave API en el campo de autorización
            //"bearer" es un tipo de autenticación que permite acceso a recursos protegidos
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            //Solicitud GET a la API con la consulta 'query' (palabra clave) y también limita los resultados a 10
            //_httpClient.GetAsync devuelve un objeto HttpResponseMessage que se llama response
            var response = await _httpClient.GetAsync($"https://api.pexels.com/v1/search?query={query}&per_page=10");
            //Asegura que la respuesta de la solicitud fue exitosa
            response.EnsureSuccessStatusCode();

            //Leer contenido de la respuesta como string
            //response.content es el contenido de la respuesta del API como string
            //content entonces es la cadena JSON que contiene la respuesta del API
            //response.content tiene los datos crudos en formato JSON devueltos por la API
            var content = await response.Content.ReadAsStringAsync();
            //Deserializa contenido del JSON  a un objeto dinámico
            //searchResponse permite acceder a las propiedades del JSON de manera más sencilla en el código
            //dynamic  permite accesar a las propiedades del JSON de manera directa y flexible, sin clases intermedias
            var searchResponse = JsonConvert.DeserializeObject<dynamic>(content);

            //Recorre cada foto en la respuesta deserializada y crea una lista con los datos de la imagen y el fotógrafo (lo del modelo)
            var pictures = new List<PictureModel>();
            //Verificar que searchResponse no esté vacío
            if (searchResponse.photos != null)
            {
                //Loop para la colección de fotos obtenida de la respuesta JSON deserializada
                foreach (var photo in searchResponse.photos)
                {
                    //Para cada picture, se crea un modelo con sus dos propiedades
                    //El API tiene atributo photo.src con diferentes tamaños, es la estructura que trae el JSON
                    pictures.Add(new PictureModel
                    {
                        Url = photo.src.medium,
                        Photographer = photo.photographer
                    });
                }
            }
            //Devuelve la lista
            return pictures;
        }
    }
}


/*Así se ve response.content como JSON string // searchResponse es el objeto deserializado en C# pero parece que se ve parecido 
 * {
    "total_results": 1000,
    "page": 1,
    "per_page": 10,
    "photos": [
        {
            "id": 12345,
            "width": 4000,
            "height": 3000,
            "url": "https://www.pexels.com/photo/12345",
            "photographer": "John Doe",
            "src": {
                "original": "https://images.pexels.com/photos/12345/original.jpg",
                "medium": "https://images.pexels.com/photos/12345/medium.jpg"
            }
        }
        // Otros objetos de fotos
    ]
}*/
