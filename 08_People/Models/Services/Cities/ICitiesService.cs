using _08_People.Models.Entity;
using _08_People.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Services
{
    public interface ICitiesService
    {
        City Add(CreateCityViewModel city);
        List<City> All();
        List<City> Search(string search);
        City FindById(int id);
        bool Edit(int id, CreateCityViewModel city);
        bool Remove(int id);
    }
}
