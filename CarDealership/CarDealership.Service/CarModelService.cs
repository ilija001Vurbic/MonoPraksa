
using CarDealership.Common;
using CarDealership.Model;
using CarDealership.Repository;
using CarDealership.Repository.Common;
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
        public CarModelService(ICarModelRepositoryCommon repository)
        {
            this.repository = repository;
        }
        private ICarModelRepositoryCommon repository { get; set; }
        public async Task<List<CarModel>> GetAllModels(CarParameters carParameters)
        {
            List<CarModel> models = await repository.GetAllModels(carParameters);
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
