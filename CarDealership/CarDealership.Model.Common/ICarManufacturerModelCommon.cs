using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model.Common
{
    public interface ICarManufacturerModelCommon
    {
        int Id { get; set; }
        string Name { get; set; }
        string Country { get; set; }
    }
}
