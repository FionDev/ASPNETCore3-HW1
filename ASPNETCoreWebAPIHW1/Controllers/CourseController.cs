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
    public class CourseController : ControllerBase
    {
        private readonly ContosouniversityContext DB;
        public CourseController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        // GET api/course
        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourse()
        {
           return this.DB.Course.Where(d => d.IsDeleted == null || d.IsDeleted == false).ToList();
        }

        // GET api/course/5
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            return this.DB.Course.Where(d => (d.IsDeleted == null || d.IsDeleted == false)&&d.CourseId==id).FirstOrDefault();
        }

        // POST api/course
        [HttpPost("")]
        public void Poststring(Course value)
        {
            value.DateModified=DateTime.Now;
            this.DB.Course.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/course/5
        [HttpPut("{id}")]
        public void PutCourse(int id, Course value)
        {
            value.DateModified=DateTime.Now;
            this.DB.Course.Update(value);
            this.DB.SaveChanges();
        }

        // DELETE api/course/5
        [HttpDelete("{id}")]
        public void DeleteCourseById(int id)
        {
            var t = this.DB.Course.Find(id);
            t.DateModified=DateTime.Now;
            t.IsDeleted = true;
            this.DB.Remove(t);
            this.DB.SaveChanges();
        }



        // db view  VwCourseStudentCount
        // GET api/vwcoursestudentcount
        [HttpGet("")]
        public ActionResult<IEnumerable<VwCourseStudentCount>> GetVwCourseStudent()
        {
           
            return this.DB.VwCourseStudentCount.ToList();
        }

        // GET api/vwcoursestudentcount/5
        [HttpGet("{id}")]
        public ActionResult<VwCourseStudentCount> GetVwCourseStudentById(int id)
        {
            return this.DB.VwCourseStudentCount.Find(id);
        }

        //db view VwCourseStudents
        // GET api/vwcoursestudents
        [HttpGet("")]
        public ActionResult<IEnumerable<VwCourseStudents>> GetVwCourseStudents()
        {
            return this.DB.VwCourseStudents.ToList();
        }

        // GET api/vwcoursestudents/5
        [HttpGet("{id}")]
        public ActionResult<VwCourseStudents> GetVwCourseStudentsById(int id)
        {
            return this.DB.VwCourseStudents.Find(id);
        }
    }
}
