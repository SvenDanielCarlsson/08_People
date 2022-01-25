using _08_People.Models.Entity;
using _08_People.Models.Services;
using _08_People.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICitiesService _citiesService;
        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }



        [HttpGet]
        public IActionResult Index(string search)
        {
            CitiesViewModel cities = new CitiesViewModel { Cities = _citiesService.Search(search) }; // Change to search?
            return View(cities);
        }

        //[HttpGet]
        //public IActionResult Index(int id)
        //{
        //    City city = _citiesService.FindById(id);
        //    //CitiesViewModel cities = new CitiesViewModel { Cities = _citiesService.Search(search) }; // Change to search?
        //    return View(cities);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel createCity = new CreateCityViewModel();
            return View(createCity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCityViewModel city)
        {
            if (ModelState.IsValid)
            {
                _citiesService.Add(city);
                return RedirectToAction(nameof(Index)); // Redirect to countries list of cities
            }
            return RedirectToAction(nameof(Create));
        }

        public ActionResult Edit(int id)    // Not implemented
        {
            //Person person = _peopleService.FindById(id);
            //if (person == null) { return RedirectToAction(nameof(Index)); }

            //CreatePersonViewModel editPerson = new CreatePersonViewModel()
            //{
            //    //Id = person.Id,   //Add and set Id in CreatePersonViewModel??
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,
            //    PhoneNumber = person.PhoneNumber,
            //    InCity = person.InCity
            //};

            //ViewBag.Id = id;
            //return View(editPerson);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()    // Not implemented (int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
