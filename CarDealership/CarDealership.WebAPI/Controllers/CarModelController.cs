using CarDealership.Model;
using CarDealership.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership.WebAPI.Controllers
{
    public class CarModelController : ApiController
    {
        // GET: CarModel
        CarModelService service = new CarModelService();
        public HttpResponseMessage GetModels()
        {
            List<CarModel> models = new List<CarModel>();
            if (models == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            models = service.GetAllModels();
            return Request.CreateResponse(HttpStatusCode.OK, models);
        }
        public CarModel GetModelById(int id)
        {
            return service.GetModelById(id);
        }
        public void DeleteModel(CarModel model)
        {
            service.DeleteCarModel(model);
        }
        public HttpResponseMessage PutModel(int id, CarModel model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PutCarModel(id,model);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        public HttpResponseMessage PostModel(CarModel model)
        {
            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            service.PostCarModel(model);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}