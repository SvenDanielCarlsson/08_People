using _08_People.Models.Entity;
using _08_People.Models.Repos;
using _08_People.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICitiesRepo _citiesRepo;

        public PeopleService(IPeopleRepo peopleRepo, ICitiesRepo citiesRepo)
        {
            _peopleRepo = peopleRepo;
            _citiesRepo = citiesRepo;
        }


        public Person Add(CreatePersonViewModel newPerson)
        {
            if (newPerson == null)
            {
                return null;
            }
            else
            {
                Person person = new Person()
                {
                    FirstName = newPerson.FirstName,
                    LastName = newPerson.LastName,
                    PhoneNumber = newPerson.PhoneNumber,
                    CityId = newPerson.CityId
                };

                person = _peopleRepo.Create(person);
                return person;
                //return _peopleRepo.Create(person);
            }
        }

        public List<Person> All()
        {
            return _peopleRepo.Read();
        }

        public Person FindById(int id)
        {
            return _peopleRepo.Read(id);
        }
        
        public List<Person> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return All();
            }
            else
            {
                List<Person> result = All().Where(x => 
                                            x.FirstName.ToLower().Contains(search.ToLower()) ||
                                            x.LastName.ToLower().Contains(search.ToLower()) ||
                                            x.City.CityName.ToLower().Contains(search.ToLower())
                                            ).ToList();

                if (result.Count < 1)
                {
                    return All();
                    // add partial view saying search results found nothing?
                }
                else
                {
                return (List<Person>)result;
                }
            }
        }

        public bool Edit(int id, CreatePersonViewModel ePerson)
        {
            Person person = FindById(id);

            if (person != null)
            {
                person.FirstName = ePerson.FirstName;
                person.LastName = ePerson.LastName;
                person.PhoneNumber = ePerson.PhoneNumber;
                person.CityId = ePerson.CityId;

                return _peopleRepo.Update(person);
            }
            return false;
        }

        public bool Remove(int id)
        {
            Person person = FindById(id);

            if (person != null)
            {
                return _peopleRepo.Delete(person);
            }
            return false;
        }


    }
}
