using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using Student.Models;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Student.Models
{
    public class Employee_Info
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your name")]
        public string Emp_Name { get; set; }

        [Required(ErrorMessage = "Enter your Address")]
        public string Emp_Address { get; set; }

        [Required(ErrorMessage = "Enter your Country")]
        public int? Country { get; set; }

        [Required(ErrorMessage = "Enter your State")]
        public int? State { get; set; }

        [Required(ErrorMessage = "Enter your City")]
        public int? City { get; set; }

        [Required(ErrorMessage = "Enter your DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Birth { get; set; }

        [Required(ErrorMessage = "Enter your Phone Number")]
        public string Phone { get; set; }

        public Country_Info Countrydb { get; set; }
        public State_info Statedb { get; set; }
        public City_Info Citydb { get; set; }

        public CountryModel CountryMd { get; set;}
        public StateModel StateMd { get; set; }
        public CityModel CityMd { get; set; }
    }
}