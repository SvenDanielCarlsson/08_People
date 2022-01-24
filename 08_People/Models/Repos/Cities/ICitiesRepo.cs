using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public interface ICitiesRepo
    {
        //C
        City Create(City city);

        //R
        List<City> Read();
        City Read(int id);

        //U
        bool Update(City city);

        //D
        bool Delete(City city);
    }
}
