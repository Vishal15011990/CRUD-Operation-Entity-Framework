using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using Student.Models.Db_Operation;
using PagedList;
using PagedList.Mvc;
using System.Diagnostics;

namespace Student.Controllers
{
    public class DefaultController : Controller
    {
        Employee_DbOperation db = null;
        EmployeeEntities emp = new EmployeeEntities();

        public DefaultController()
        {
            db = new Employee_DbOperation();
        }
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            List<Country_Info> count_Info = emp.Country_Info.ToList();
            ViewBag.CountryInfo = new SelectList(count_Info, "Country_Id", "Country_name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee_Info emp)
        {
            int id = db.Create(emp);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }
            }
            return RedirectToAction("GetRecord");
        }

        public ActionResult GetCountry(int cid)
        {
            List<State_info> state_Infos = emp.State_info.Where(x => x.Country_RefId == cid).ToList();
            ViewBag.state_Infos = new SelectList(state_Infos, "State_Id", "State_Name");
            return PartialView("StateList");
        }
        public ActionResult GetState(int sid)
        {
            List<City_Info> city_Infos = emp.City_Info.Where(x => x.State_RefId == sid).ToList();
            ViewBag.city_Infos = new SelectList(city_Infos, "City_Id", "City_Name");
            return PartialView("CityList");
        }

        public ActionResult GetRecordsDetail(int id)
        {
            var result = db.Details(id);
            return View(result);
        }
        public ActionResult GetRecord(string search ,int? page,string sort)
        {
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";

            var result = db.Details().AsQueryable();
            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Emp_Name.StartsWith(search) || search == null);
            }
            switch(sort)
            {
                case "descending name":
                    result = result.OrderByDescending(x=>x.Emp_Name);
                    break;

                default:
                    result = result.OrderBy(x => x.Emp_Name);
                    break;
            }
            return View(result.ToPagedList(page ?? 1, 4));
           
        }

        public ActionResult Edit(int id)
        {
            List<Country_Info> count_Info = emp.Country_Info.ToList();
            ViewBag.CountryInfo = new SelectList(count_Info, "Country_Id", "Country_name");
            var result = db.Details(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Employee_Info emp)
        {
            db.UpdateModel(emp.Id, emp);
            return RedirectToAction("GetRecord");
        }
        public ActionResult Delete(int id)
        {
            db.DeleteModel(id);
            return RedirectToAction("GetRecord");
        }
    }
}