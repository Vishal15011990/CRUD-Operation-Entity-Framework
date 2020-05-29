using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class CityModel
    {
        public int City_Id { get; set; }
        public int? State_RefId { get; set; }
        public string City_Name { get; set; }
    }
}