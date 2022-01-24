using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _08_People.Models.Entity;

namespace _08_People.Data
{
    internal class DbInitializer
    {
        internal static void Initialize(PeopleDbContext context)
        {
            context.Database.EnsureCreated();     // If NOT using EF migrations, keeping both for ensurance
            //context.Database.Migrate();


            if (context.Countries.Any())       // Check if database is being seeded
            {
                return;     //return in this case is just to break from the code
            }


            // if context is empty, seeding this into DB

            //context.People.Add(new Person() { FirstName = "Daniel", LastName = "Carlsson", PhoneNumber = 0730001122, City = "Växjö" });
            context.Countries.Add(new Country("Norway"));
            context.SaveChanges();
        }
    }
}
