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
        List<CarManufacturer> GetAllManufacturers();
        CarManufacturer GetManufacturerById(int id);
        CarManufacturer PostCarManufacturer(CarManufacturer manufacturer);
        void PutCarManufacturer(int id, CarManufacturer manufacturer);
        void DeleteCarManufacturer(CarManufacturer manufacturer);
    }
}
