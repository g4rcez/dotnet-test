using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetTest.Domain;
using dotnetTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static PeopleRepository repository = new PeopleRepository();

        [HttpGet]
        public ActionResult<IEnumerable<People>> Get()
        {
            return repository.All();
        }

        [HttpGet("orderByEmail")]
        public ActionResult<IEnumerable<People>> OrderByEmail()
        {
            Console.WriteLine(repository.OrderByEmail());
            return repository.OrderByEmail();
        }

        [HttpGet("/find/{id}")]
        public ActionResult<People> Get(string id)
        {
            return repository.One(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<People> Post([FromBody] People value)
        {
            return repository.Save(value);
        }

        [HttpPut("{id}")]
        public ActionResult<People> Put(string id, [FromBody] People value)
        {
            return repository.Update(value, id);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            return repository.Delete(id);
        }
    }
}
