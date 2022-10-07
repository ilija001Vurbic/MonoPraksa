using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Service.Common
{
    public interface ICarService
    {
        Task<List<CarManufacturer>> GetAllManufacturers();
        Task<CarManufacturer> GetManufacturerById(int id);
        Task PostCarManufacturer(CarManufacturer manufacturer);
        Task PutCarManufacturer(int id, CarManufacturer manufacturer);
        Task DeleteCarManufacturer(CarManufacturer manufacturer);
    }
}
