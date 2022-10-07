using CarDealership.Model;
using CarDealership.Service;
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
        // GET: CarModel
        CarModelService service = new CarModelService();
        [HttpGet]
        public async Task<HttpResponseMessage> GetModels()
        {
            List<CarModel> models = await service.GetAllModels();
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
                CarModelRest modelRest = new CarModelRest(model.Id, model.ManufacturerId, model.Model, model.Engine, model.Price);
                modelsRest.Add(modelRest);
            }
            return modelsRest;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetModelById(int id)
        {
            CarModel model = await service.GetModelById(id);
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteModel(CarModel model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.DeleteCarModel(model);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPut]
        public async Task<HttpResponseMessage> PutModel(int id, CarModel model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PutCarModel(id,model);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostModel(CarModelRest modelRest)
        {
            if (modelRest == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PostCarModel(modelRest);
            return Request.CreateResponse(HttpStatusCode.OK, modelRest);
        }
       
    }
}