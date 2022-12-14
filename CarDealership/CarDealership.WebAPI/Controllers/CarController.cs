using AutoMapper;
using CarDealership.Common;
using CarDealership.Model;
using CarDealership.Model.Common;
using CarDealership.Service;
using CarDealership.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership.WebAPI.Controllers
{
    public class CarController : ApiController
    {
        private ICarService service { get; set; }
        public IMapper mapper { get; set; }
        public CarController(ICarService service)
        {
            this.service = service;
        }
        public CarController()
        {
            
        }
        public async Task<HttpResponseMessage> GetManufacturers(string query, int pageSize, int pageNumber, string sortBy, string sortOrder, DateTime madeBefore, DateTime madeAfter, bool hasBodyType)
        {
            Paging paging = new Paging( pageSize, pageNumber);
            Sorting sorting = new Sorting(sortBy, sortOrder);
            Filtering filtering = new Filtering(madeBefore,madeAfter,hasBodyType);
            List<CarManufacturer> manufacturers = await service.GetAllManufacturers(paging, sorting,filtering);
            if (manufacturers == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, manufacturers);
        }
        public async Task<HttpResponseMessage> GetManufacturerById(int id)
        {
            CarManufacturer manufacturer = await service.GetManufacturerById(id);
            if (manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, manufacturer);
        }

        public async Task<HttpResponseMessage> PostManufacturer(CarManufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PostCarManufacturer(manufacturer);
            return Request.CreateResponse(HttpStatusCode.OK, manufacturer);
            
        }
        
        public async Task<HttpResponseMessage> PutManufacturer(int id, CarManufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,id);
            }
            service.PutCarManufacturer(id,manufacturer);
            return Request.CreateResponse(HttpStatusCode.OK, manufacturer);
        }
        
        public async Task<HttpResponseMessage> DeleteManufacturer(CarManufacturer manufacturer)
        {
            if(manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.DeleteCarManufacturer(manufacturer);
            return Request.CreateResponse(HttpStatusCode.OK, manufacturer);
        }

    }
    }