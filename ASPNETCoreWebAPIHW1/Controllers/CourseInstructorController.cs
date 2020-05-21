
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
    public class CourseInstructorController : ControllerBase
    {
        private readonly ContosouniversityContext DB;
        public CourseInstructorController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        // GET api/courseinstructor
        [HttpGet("")]
        public ActionResult<IEnumerable<CourseInstructor>> GetCourseInstructor()
        {
            return this.DB.CourseInstructor.ToList();
        }

        // GET api/courseinstructor/5
        [HttpGet("{id}")]
        public ActionResult<CourseInstructor> GetCourseInstructorById(int id)
        {
            return this.DB.CourseInstructor.Find(id);
        }

        // POST api/courseinstructor
        [HttpPost("")]
        public void PostCourseInstructor(CourseInstructor value)
        {
            this.DB.CourseInstructor.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/courseinstructor/5
        [HttpPut("{id}")]
        public void PutCourseInstructor(int id, CourseInstructor value)
        {
            this.DB.CourseInstructor.Update(value);
            this.DB.SaveChanges();
        }

        // DELETE api/courseinstructor/5
        [HttpDelete("{id}")]
        public void DeleteCourseInstructorById(int id)
        {
            var t = this.DB.CourseInstructor.Find(id);
            this.DB.Remove(t);
            this.DB.SaveChanges();
        }
    }
}