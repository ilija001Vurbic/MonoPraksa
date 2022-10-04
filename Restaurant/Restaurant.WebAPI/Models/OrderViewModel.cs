using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.WebAPI.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Price { get; set; }

    }
}