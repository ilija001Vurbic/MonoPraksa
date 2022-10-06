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
    public class CarService:ICarService
    {
        CarRepository repository = new CarRepository();
        public List<CarManufacturer> GetAllManufacturers() {
            List<CarManufacturer> manufacturers = new List<CarManufacturer>();
            manufacturers = repository.GetAllManufacturers();
            return manufacturers;
        }

        public CarManufacturer GetManufacturerById(int id)
        {
            return repository.GetManufacturerById(id);
        }
        
        public void PostCarManufacturer(CarManufacturer manufacturer)
        {
            repository.PostCarManufacturer(manufacturer);
        }
       
        public void PutCarManufacturer(int id, CarManufacturer manufacturer)
        {
            repository.PutCarManufacturer(id, manufacturer);
        }
       
        public void DeleteCarManufacturer(CarManufacturer manufacturer)
        {
            repository.DeleteCarManufacturer(manufacturer);
        }
    }
}
