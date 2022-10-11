using CarDealership.Common;
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
        Task<List<CarModel>> GetAllModels(CarParameters carParameters);
        Task<CarModel> GetModelById(int id);
        Task PostCarModel(CarModelRest modelRest);
        Task PutCarModel(int id, CarModel model);
        Task DeleteCarModel(CarModel model);
    }
}
