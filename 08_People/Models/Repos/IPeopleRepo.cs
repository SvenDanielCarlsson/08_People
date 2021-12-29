using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public interface IPeopleRepo
    {
        //C
        Person Create(Person person);
        //R
        List<Person> Read();
        Person Read(int id);
        //U
        bool Update(Person person);
        //D
        bool Delete(Person person);
    }
}
