using _08_People.Data;
using _08_People.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }




        public Person Create(Person person)
        {
            //_peopleDbContext.People.Include(c => c.City);
            _peopleDbContext.People.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.People.Include(c => c.City).ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.People.Include(c => c.City).ThenInclude(c => c.Country).SingleOrDefault(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            _peopleDbContext.People.Update(person);
            _peopleDbContext.SaveChanges();
            return true;        // THIS IS BAD, FIGURE OUT A BETTER WAY!
        }

        public bool Delete(Person person)
        {
            _peopleDbContext.People.Remove(person);
            _peopleDbContext.SaveChanges();
            return true;        // THIS IS STILL BAD PRACTICE!
        }
    }
}
