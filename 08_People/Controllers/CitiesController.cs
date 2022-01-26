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
        private readonly ICountriesService _countriesService;
        public CitiesController(ICitiesService citiesService, ICountriesService countriesService)
        {
            _citiesService = citiesService;
            _countriesService = countriesService;
        }



        [HttpGet]
        public IActionResult Index(string search)
        {
            CitiesViewModel cities = new CitiesViewModel { Cities = _citiesService.Search(search) };
            return View(cities);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel city = new CreateCityViewModel();
            city.CountryList = _countriesService.All();
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCityViewModel city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _citiesService.Add(city);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("City & Country", exception.Message);
                    city.CountryList = _countriesService.All();

                    return View(city);
                }
                return RedirectToAction(nameof(Index));
            }

            city.CountryList = _countriesService.All();
            return RedirectToAction(nameof(Create));
        }

        //[HttpGet]
        //public IActionResult Create(int id)
        //{
        //    CreateCityViewModel city = new CreateCityViewModel();
        //    city.CountryId = id;
        //    return View(city);
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            City city = _citiesService.FindById(id);
            if (city == null) { RedirectToAction(nameof(Index)); }
            return View(city);

            //Country country = _countriesService.FindById(id);
            //if (country == null) { RedirectToAction(nameof(Index)); }
            //return View(country);
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
