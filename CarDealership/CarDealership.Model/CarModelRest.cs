using CarDealership.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class CarModelRest:ICarModelRestCommon
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Price { get; set; }
        public CarModelRest(int id, int manufacturerId, string model, string engine, int price)
        {
            Id = id;
            ManufacturerId = manufacturerId;
            Model = model;
            Engine = engine;
            Price = price;
        }

    }
}
