using System;
using System.Collections.Generic;
using System.Linq;
using dotnetTest.Domain;

namespace dotnetTest.Repository
{
    public class PeopleRepository : IRepository<People, string>
    {
        public static List<People> list = new List<People>();
        public List<People> All() => new List<People>(list);
        public People One(string id) => list.Single(people => people.Id == id);

        public bool Delete(string id)
        {
            var len = list.Count;
            list.Where(people => people.Id != id).ToList();
            return len == list.Count;
        }

        public People Save(People entity)
        {
            var immutablePeople = new People
            {
                Email = entity.Email,
                Id = Guid.NewGuid().ToString(),
                Name = entity.Name,
                Status = entity.Status
            };
            list.Add(immutablePeople);
            return immutablePeople;
        }

        public People Update(People entity, string id)
        {
            list = list.Select(people =>
            {
                if (people.Id == id)
                {
                    return new People
                    {
                        Email = entity.Email,
                        Id = id,
                        Name = entity.Name,
                        Status = entity.Status
                    };
                }
                return people;
            }).ToList();
            return entity;
        }

        public List<People> OrderByEmail()
        {
            return list.OrderBy(people => people.Email).ToList();
        }
    }
}