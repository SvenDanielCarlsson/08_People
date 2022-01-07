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


        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel newPerson)
        {
            // if any data is empty, should throw argumentexception
            Person person = new Person()
            {
                Id = InMemoryPeopleRepo.IdCounter,
                FirstName = newPerson.FirstName,
                LastName = newPerson.LastName,
                PhoneNumber = newPerson.PhoneNumber,
                InCity = newPerson.InCity
            };

            if(person == null)
            {
                return null;
            }
            else
            {
                person = _peopleRepo.Create(person);
                return person;
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
                                            x.InCity.ToLower().Contains(search.ToLower())
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

        public bool Edit(int id, CreatePersonViewModel alterPerson)
        {
            //Person person = _peopleRepo.Read(id);
            Person person = FindById(id);

            if (person != null)
            {
                person.Id = id;     //                  <------------    Really neccessary?
                person.FirstName = alterPerson.FirstName;
                person.LastName = alterPerson.LastName;
                person.PhoneNumber = alterPerson.PhoneNumber;
                person.InCity = alterPerson.InCity;

                _peopleRepo.Update(person);
                return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            Person person = FindById(id); // OR _peopleRepo.Read(id);
            if (person != null)
            {
                _peopleRepo.Delete(person);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
