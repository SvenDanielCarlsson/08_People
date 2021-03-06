using _08_People.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08_People.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> people = new List<Person>();
        private static List<Person> People { get { return people; } set { people = value; } }

        private static int idCounter = 1;
        private static int IdCounter { get { return idCounter++; } }



        public Person Create(Person person)
        {
            person.Id = IdCounter;
            People.Add(person);

            return person;
        }

        public List<Person> Read()
        {
            return People;
        }

        public Person Read(int id)
        {
            return People.SingleOrDefault(People => People.Id == id);
        }

        public bool Update(Person person)
        {
            //if (person == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    //people.Update(person) is wrong
            //}
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            if (person == null)
            {
                return false;
            }
            else
            {
                return People.Remove(person);  // Add a check for if remove was successfull?
            }
        }
    }
}
