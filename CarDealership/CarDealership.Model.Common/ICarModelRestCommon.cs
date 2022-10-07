using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model.Common
{
    public interface ICarModelRestCommon
    {
        int Id { get; set; }
        int ManufacturerId { get; set; }
        string Model { get; set; }
        string Engine { get; set; }
        int Price { get; set; }
    }
}
