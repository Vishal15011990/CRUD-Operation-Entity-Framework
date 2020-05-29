using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Models
{
    public class StateModel
    {
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public int? Country_RefId { get; set; }
    }
}