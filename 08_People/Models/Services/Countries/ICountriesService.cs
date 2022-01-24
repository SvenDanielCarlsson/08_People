using _08_People.Models.Entity;
using _08_People.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Services
{
    public interface ICountriesService
    {
        Country Add(CreateCountryViewModel country);
        List<Country> All();
        List<Country> Search(string search);
        Country FindById(int id);
        bool Edit(int id, CreateCountryViewModel country);
        bool Remove(int id);
    }
}
