using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.ModelBinding;

namespace Student.Models.Db_Operation
{
    public class Employee_DbOperation
    {
        public int Create(Employee_Info emp)
        {
            using (var context = new EmployeeEntities())
            {
                Emp_Info emp2 = new Emp_Info()
                {
                    Id = emp.Id,
                    Emp_Name = emp.Emp_Name,
                    Emp_Address = emp.Emp_Address,
                    Country = emp.Countrydb.Country_Id,
                    State = emp.Statedb.State_Id,
                    City = emp.Citydb.City_Id,
                    Date_of_Birth = emp.Date_of_Birth,
                    Phone = emp.Phone,

                };

                context.Entry(emp2).State = EntityState.Added;
                context.SaveChanges();

                return emp2.Id;
            }
        }

        public List<Employee_Info> Details()
        {
            using (var context = new EmployeeEntities())
            {
                var result = context.Emp_Info.Select(x => new Employee_Info()
                {
                    Id = x.Id,
                    Emp_Name = x.Emp_Name,
                    Emp_Address = x.Emp_Address,
                    Phone = x.Phone,
                    Date_of_Birth = x.Date_of_Birth,
                    CountryMd = new CountryModel()
                    {
                        Country_Id = x.Country_Info.Country_Id,
                        Country_name = x.Country_Info.Country_name,
                    },
                    StateMd = new StateModel()
                    {
                        State_Id = x.State_info.State_Id,
                        State_Name = x.State_info.State_Name,
                    },
                    CityMd = new CityModel()
                    {
                        City_Id = x.City_Info.City_Id,
                        City_Name = x.City_Info.City_Name,
                    }

                }).ToList();
                return result;
            }
        }
        public Employee_Info Details(int id)
        {
            using (var context = new EmployeeEntities())
            {
                var result = context.Emp_Info.Where(x => x.Id == id).Select(x => new Employee_Info()
                {
                    Id = x.Id,
                    Emp_Name = x.Emp_Name,
                    Emp_Address = x.Emp_Address,
                    Phone = x.Phone,
                    Date_of_Birth = x.Date_of_Birth,
                    CountryMd = new CountryModel()
                    {
                        Country_Id = x.Country_Info.Country_Id,
                        Country_name = x.Country_Info.Country_name,
                    },
                    StateMd = new StateModel()
                    {
                        State_Id = x.State_info.State_Id,
                        State_Name = x.State_info.State_Name,
                        Country_RefId = x.State_info.Country_RefId,
                    },
                    CityMd = new CityModel()
                    {
                        City_Id = x.City_Info.City_Id,
                        City_Name = x.City_Info.City_Name,
                        State_RefId = x.City_Info.State_RefId,
                    }

                }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateModel(int id, Employee_Info emp)
        {
            using (var context = new EmployeeEntities())
            {
                var employee = context.Emp_Info.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Emp_Name = emp.Emp_Name;
                    employee.Date_of_Birth = emp.Date_of_Birth;
                    employee.Emp_Address = emp.Emp_Address;
                    employee.Phone = emp.Phone;
                    employee.Country = emp.CountryMd.Country_Id;
                    employee.State = emp.StateMd.State_Id;
                    employee.City = emp.CityMd.City_Id;
                }
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }

        public bool DeleteModel(int id)
        {
            using (var context = new EmployeeEntities())
            {
                var emp = context.Emp_Info.FirstOrDefault(x => x.Id == id);
                context.Entry(emp).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return true;
        }
    }
}