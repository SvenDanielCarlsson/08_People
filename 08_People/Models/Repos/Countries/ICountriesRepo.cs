using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public interface ICountriesRepo
    {
        //C
        Country Create(Country country);

        //R
        List<Country> Read();
        Country Read(int id);

        //U
        bool Update(Country country);

        //D
        bool Delete(Country country);
    }
}
