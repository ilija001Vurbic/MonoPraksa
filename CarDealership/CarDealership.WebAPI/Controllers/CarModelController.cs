using AutoMapper;
using CarDealership.Common;
using CarDealership.Model;
using CarDealership.Service;
using CarDealership.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace CarDealership.WebAPI.Controllers
{
    public class CarModelController : ApiController
    {
        private ICarModelService service { get; set; }
        private IMapper mapper { get; set; }
        public CarModelController(ICarModelService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllModels(int pageNumber = 1, int pageSize = 5)
        {
            //string sortBy,string sortOrder, DateTime? madeBefore, DateTime? madeAfter, bool hasBodyType

            //sortBy = "model";
            //sortOrder = "ascending";

            //madeBefore = null;
            //madeAfter = null;
            //hasBodyType = false;
            Paging paging = new Paging(pageNumber,pageSize);
            //Sorting sorting = new Sorting(sortBy, sortOrder);
            //Filtering filtering = new Filtering(madeBefore,madeAfter,hasBodyType);
            List<CarModel> models = await service.GetAllModels(paging);
            List<CarModelRest> modelsRest = MapToRest(models);
            if (models == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, modelsRest);
        }
        public List<CarModelRest> MapToRest(List<CarModel> models)
        {
            List<CarModelRest> modelsRest = new List<CarModelRest>();
            if (models == null)
            {
                return null;
            }
            foreach (CarModel model in models)
            {
                CarModelRest modelRest = mapper.Map<CarModelRest>(model);
                modelsRest.Add(modelRest);
            }
            return modelsRest;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetModelById(int id)
        {
            CarModel model = await service.GetModelById(id);
            CarModelRest carModel = mapper.Map<CarModelRest>(model);
            if (carModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, carModel);
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteModel(CarModel model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.DeleteCarModel(model);
            CarModelRest carModel = mapper.Map<CarModelRest>(model);
            return Request.CreateResponse(HttpStatusCode.OK, carModel);
        }
        [HttpPut]
        public async Task<HttpResponseMessage> PutModel(int id, CarModel model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PutCarModel(id,model);
            CarModelRest carModel = mapper.Map<CarModelRest>(model);
            return Request.CreateResponse(HttpStatusCode.OK, carModel);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostModel(CarModelRest modelRest)
        {
            if (modelRest == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PostCarModel(modelRest);
            CarModel carModel = mapper.Map<CarModel>(modelRest);
            return Request.CreateResponse(HttpStatusCode.OK, carModel);
        }
       
    }
}