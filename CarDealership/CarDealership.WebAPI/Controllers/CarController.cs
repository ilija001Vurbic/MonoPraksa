using CarDealership.Model;
using CarDealership.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership.WebAPI.Controllers
{
    public class CarController : ApiController
    {
        CarService service = new CarService();
        public HttpResponseMessage GetManufacturers()
        {
            List<CarManufacturer> manufacturers = new List<CarManufacturer>();
            if (manufacturers == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            manufacturers = service.GetAllManufacturers();
            return Request.CreateResponse(HttpStatusCode.OK, manufacturers);
        }
        public CarManufacturer GetManufacturerById(int id)
        {
            return service.GetManufacturerById(id);
        }

        public HttpResponseMessage PostManufacturer(CarManufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PostCarManufacturer(manufacturer);
            return Request.CreateResponse(HttpStatusCode.OK, manufacturer);
            
        }
        
        public void PutManufacturer(int id, CarManufacturer manufacturer)
        {
            service.PutCarManufacturer(id, manufacturer);
        }
        
        public void DeleteManufacturer(CarManufacturer manufacturer)
        {
            service.DeleteCarManufacturer(manufacturer);
        }

    }
    }