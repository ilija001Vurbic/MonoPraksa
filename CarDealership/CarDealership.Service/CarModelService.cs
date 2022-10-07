
using CarDealership.Model;
using CarDealership.Repository;
using CarDealership.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Service
{
    public class CarModelService:ICarModelService
    {
        CarModelRepository repository = new CarModelRepository();
        public async Task<List<CarModel>> GetAllModels()
        {
            List<CarModel> models = await repository.GetAllModels();
            return models;
        }

        public async Task<CarModel> GetModelById(int id)
        {
            CarModel model = await repository.GetModelById(id);
            return model;
        }
        public async Task PostCarModel(CarModelRest model)
        {
            repository.PostCarModel(model);
        }
        public async Task PutCarModel(int id, CarModel model)
        {
            repository.PutCarModel(id, model);
        }
        public async Task DeleteCarModel(CarModel model)
        {
            repository.DeleteCarModel(model);
        }
    }
}
