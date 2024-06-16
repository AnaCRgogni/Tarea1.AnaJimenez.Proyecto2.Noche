using BL.DAOs;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    //Intermediario entre DAO y el controlador del API, tiene lógica de negocios adicional si es necesario
    public class PictureService
    {
        //Crea instancia del DAO que le pasamos a la clase por el constructor
        private readonly PictureDao _pictureDao;

        //Inyectar dependencia
        public PictureService(PictureDao pictureDao)
        {
            _pictureDao = pictureDao;
        }

        public Task<List<PictureModel>> SearchPicturesAsync(string query)
        {
            return _pictureDao.SearchPicturesAsync(query);
        }
    }
}
