using CarDealership.Common;
using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repository.Common
{
    public interface ICarRepository
    {
        Task<List<CarManufacturer>> GetAllManufacturers(Paging paging,Sorting sorting, Filtering filtering);
        Task<CarManufacturer> GetManufacturerById(int id);
        Task<CarManufacturer> PostCarManufacturer(CarManufacturer manufacturer);
        Task<CarManufacturer> PutCarManufacturer(int id, CarManufacturer manufacturer);
        Task DeleteCarManufacturer(CarManufacturer manufacturer);
    }
}
