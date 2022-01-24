using _08_People.Data;
using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public class DatabaseCitiesRepo : ICitiesRepo
    {
        private readonly PeopleDbContext _peopleDbContext;
        public DatabaseCitiesRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }




        public City Create(City city)
        {
            _peopleDbContext.Cities.Add(city);
            _peopleDbContext.SaveChanges();
            return city;
            //throw new NotImplementedException();
        }

        public List<City> Read()
        {
            return _peopleDbContext.Cities.ToList();
        }

        public City Read(int id)
        {
            return _peopleDbContext.Cities.SingleOrDefault(c => c.Id == id);
        }

        public bool Update(City city)
        {
            _peopleDbContext.Cities.Update(city);
            _peopleDbContext.SaveChanges();
            return true;
        }

        public bool Delete(City city)
        {
            _peopleDbContext.Cities.Remove(city);
            _peopleDbContext.SaveChanges();
            return true;
        }
    }
}
