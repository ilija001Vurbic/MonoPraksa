using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repository.Common
{
    public interface ICarModelRepositoryCommon
    {
        List<CarModel> GetAllModels();
        CarModel GetModelById(int id);
        CarModel PostCarModel(CarModel model);
        CarModel PutCarModel(int id, CarModel model);
        void DeleteCarModel(CarModel model);
    }
}
