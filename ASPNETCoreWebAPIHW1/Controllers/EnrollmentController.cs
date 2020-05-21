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
    public class EnrollmentController : ControllerBase
    {
        private readonly ContosouniversityContext DB;
        public EnrollmentController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        // GET api/enrollment
        [HttpGet("")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollment()
        {
            return this.DB.Enrollment.ToList();
        }

        // GET api/enrollment/5
        [HttpGet("{id}")]
        public ActionResult<Enrollment> GetEnrollmentById(int id)
        {
            return this.DB.Enrollment.Find(id);
        }

        // POST api/enrollment
        [HttpPost("")]
        public void PostEnrollment(Enrollment value)
        {
            this.DB.Enrollment.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/enrollment/5
        [HttpPut("{id}")]
        public void PutEnrollment(int id, Enrollment value)
        {
            this.DB.Enrollment.Update(value);
            this.DB.SaveChanges();
        }

        // DELETE api/enrollment/5
        [HttpDelete("{id}")]
        public void DeleteEnrollmentById(int id)
        {
            var t = this.DB.Enrollment.Find(id);
            this.DB.Remove(t);
            this.DB.SaveChanges();
        }
    }
}