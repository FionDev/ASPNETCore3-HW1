using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebAPIHW1.Models;

namespace ASPNETCoreWebAPIHW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ContosouniversityContext DB;
        public PersonController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        // GET api/person
        [HttpGet("")]
        public ActionResult<IEnumerable<Person>> GetPerson()
        {
            return this.DB.Person.Where(d => d.IsDeleted == null || d.IsDeleted == false).ToList();
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
           return this.DB.Person.Where(d => (d.IsDeleted == null || d.IsDeleted == false)&&d.Id==id).FirstOrDefault();
        }

        // POST api/person
        [HttpPost("")]
        public void PostPerson(Person value)
        {
            value.DateModified=DateTime.Now;
            this.DB.Person.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/person/5
        [HttpPut("{id}")]
        public void PutPerson(int id, Person value)
        {
            value.DateModified=DateTime.Now;
            this.DB.Person.Update(value);
            this.DB.SaveChanges();
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public void DeletePersonById(int id)
        {
            var t = this.DB.Person.Find(id);
            t.DateModified=DateTime.Now;
            t.IsDeleted = true;
            this.DB.Remove(t);
            this.DB.SaveChanges();
        }
    }
}