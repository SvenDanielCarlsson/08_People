using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _08_People.Models.Entity;
using _08_People.Models.ViewModels;
using _08_People.Models.Services;
using _08_People.Models.Repos;

namespace _08_People.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _ipeopleService;

        public PeopleController(IPeopleService ipeopleService)
        {
            _ipeopleService = ipeopleService;
        }

        [HttpGet]
        public ActionResult Index(string search)
        {
            PeopleViewModel people = new PeopleViewModel { Persons = _ipeopleService.Search(search) };
            return View(people);
        }


        [HttpGet]
        public ActionResult Create()
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            return View(createPerson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _ipeopleService.Add(person);
                return RedirectToAction(nameof(Index));     // Redirection to "Details" would be preferred
                //if throw new argumentexception needs to be added
            }
            Console.WriteLine("Create Controller ModelState INvalid");
            return RedirectToAction(nameof(Create));
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Person person = _ipeopleService.FindById(id);
            if(person == null) { RedirectToAction(nameof(Index)); }
            //add if (person == null) redirect to index, or indicate in details view that person is gone (in case of deletion)
            return View(person);
        }


        public ActionResult Edit(int id)    // Not implemented
        {
            //Person person = _ipeopleService.FindById(id);
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
        public ActionResult Edit(int id, IFormCollection collection)    // Not implemented
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


        public ActionResult Delete()
        {
            //might use for partial view, and load with "Are you sure?" question
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Person person = _ipeopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _ipeopleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
