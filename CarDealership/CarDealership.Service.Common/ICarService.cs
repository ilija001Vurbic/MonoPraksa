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
        List<CarManufacturer> GetAllManufacturers();
        CarManufacturer GetManufacturerById(int id);
        void PostCarManufacturer(CarManufacturer manufacturer);
        void PutCarManufacturer(int id, CarManufacturer manufacturer);
        void DeleteCarManufacturer(CarManufacturer manufacturer);
    }
}
