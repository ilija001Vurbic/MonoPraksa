using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Service.Common
{
    public interface ICarModelService
    {
        List<CarModel> GetAllModels();
        CarModel GetModelById(int id);
        void PostCarModel(CarModel model);
        void PutCarModel(int id, CarModel model);
        void DeleteCarModel(CarModel model);
    }
}
