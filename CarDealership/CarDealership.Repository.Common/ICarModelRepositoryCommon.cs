using CarDealership.Common;
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
        Task<List<CarModel>> GetAllModels(Paging paging,Sorting sorting,Filtering filtering);
        Task<CarModel> GetModelById(int id);
        Task<CarModel> PostCarModel(CarModelRest modelRest);
        Task<CarModel> PutCarModel(int id, CarModel model);
        Task DeleteCarModel(CarModel model);
    }
}
