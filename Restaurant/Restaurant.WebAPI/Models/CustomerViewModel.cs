using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.WebAPI.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public OrderViewModel Order { get; set; }
    }
}