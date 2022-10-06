
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
        public List<CarModel> GetAllModels()
        {
            return repository.GetAllModels();
        }

        public CarModel GetModelById(int id)
        {
            return repository.GetModelById(id);
        }
        public void PostCarModel(CarModel model)
        {
            repository.PostCarModel(model);
        }
        public void PutCarModel(int id, CarModel model)
        {
            repository.PutCarModel(id, model);
        }
        public void DeleteCarModel(CarModel model)
        {
            repository.DeleteCarModel(model);
        }
    }
}
