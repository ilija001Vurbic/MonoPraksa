﻿using CarDealership.Model;
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
        public async Task<List<CarManufacturer>> GetAllManufacturers() {
            List<CarManufacturer> manufacturers = await repository.GetAllManufacturers();
            return manufacturers;
        }

        public async Task<CarManufacturer> GetManufacturerById(int id)
        {
            CarManufacturer manufacturer=await repository.GetManufacturerById(id);
            return manufacturer;
        }
        
        public async Task PostCarManufacturer(CarManufacturer manufacturer)
        {
            repository.PostCarManufacturer(manufacturer);
        }
       
        public async Task PutCarManufacturer(int id, CarManufacturer manufacturer)
        {
            repository.PutCarManufacturer(id, manufacturer);
        }
       
        public async Task DeleteCarManufacturer(CarManufacturer manufacturer)
        {
            repository.DeleteCarManufacturer(manufacturer);
        }
    }
}
