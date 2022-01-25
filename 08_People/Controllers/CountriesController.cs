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
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;
        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }



        [HttpGet]
        public IActionResult Index(string search)
        {
            CountriesViewModel countries = new CountriesViewModel { Countries = _countriesService.Search(search) };  //Change to search?
            return View(countries);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateCountryViewModel createCountry = new CreateCountryViewModel();
            return View(createCountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                _countriesService.Add(country);
                return RedirectToAction(nameof(Index));     // Redirection to "Details" would be preferred
                //if throw new argumentexception needs to be added
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            //Country country = _countriesService.FindById(id);
            //var send = country.Cities.ToList();
            ////CountriesViewModel countries = _countriesService.FindById(id);
            //if (send == null) { RedirectToAction(nameof(Index)); }
            //return View(send);


            Country country = _countriesService.FindById(id);
            if (country == null) { RedirectToAction(nameof(Index)); }
            return View(country);
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
