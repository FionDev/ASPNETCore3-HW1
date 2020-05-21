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
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly ContosouniversityContext DB;
        public OfficeAssignmentController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        // GET api/officeassignment
        [HttpGet("")]
        public ActionResult<IEnumerable<OfficeAssignment>> GetOfficeAssignment()
        {
            return this.DB.OfficeAssignment.ToList();
        }

        // GET api/officeassignment/5
        [HttpGet("{id}")]
        public ActionResult<OfficeAssignment> GetOfficeAssignmentById(int id)
        {
            return this.DB.OfficeAssignment.Find(id);
        }

        // POST api/officeassignment
        [HttpPost("")]
        public void PostOfficeAssignment(OfficeAssignment value)
        {
            this.DB.OfficeAssignment.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/officeassignment/5
        [HttpPut("{id}")]
        public void PutOfficeAssignment(int id, OfficeAssignment value)
        {
            this.DB.OfficeAssignment.Update(value);
            this.DB.SaveChanges();
        }

        // DELETE api/officeassignment/5
        [HttpDelete("{id}")]
        public void DeleteOfficeAssignmentById(int id)
        {
             var t = this.DB.OfficeAssignment.Find(id);
            this.DB.Remove(t);
            this.DB.SaveChanges();
        }
    }
}