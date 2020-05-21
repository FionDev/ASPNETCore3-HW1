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
    public class DepartmentController : ControllerBase
    {
        private readonly ContosouniversityContext DB;
        public DepartmentController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        // GET api/department
        [HttpGet("")]
        public ActionResult<IEnumerable<Department>> GetDepartment()
        {
            return this.DB.Department.ToList();
        }

        // GET api/department/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            return this.DB.Department.Find(id);
        }

        // POST api/department
        [HttpPost("")]
        public void PostDepartment(Department value)
        {
            this.DB.Department.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/department/5
        [HttpPut("{id}")]
        public void PutDepartment(int id, Department value)
        {
            this.DB.Department.Update(value);
            this.DB.SaveChanges();
        }

        // DELETE api/department/5
        [HttpDelete("{id}")]
        public void DeleteDepartmentById(int id)
        {
            var t = this.DB.Department.Find(id);
            this.DB.Remove(t);
            this.DB.SaveChanges();
        }
    }
}