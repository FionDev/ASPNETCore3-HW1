using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreWebAPIHW1.Models;
using Microsoft.Data.SqlClient;

namespace ASPNETCoreWebAPIHW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwDepartmentCourseCountController : ControllerBase
    {
         private readonly ContosouniversityContext DB;
        public VwDepartmentCourseCountController(ContosouniversityContext db)
        {
            this.DB=db;
        }

        //using  Raw SQL Query 的方式查詢
        // GET api/vwdepartmentcoursecount 
        [HttpGet("")]
        public ActionResult<IEnumerable<VwDepartmentCourseCount>> GetVwDepartmentCourse()
        {
            return this.DB.VwDepartmentCourseCount.FromSqlRaw("SELECT * FROM [dbo].[vwDepartmentCourseCount]").ToList();
        }

        //using  Raw SQL Query 的方式查詢
        // GET api/vwdepartmentcoursecount/5
        [HttpGet("{id}")]
        public ActionResult<VwDepartmentCourseCount> GetstringById(int id)
        {
            return this.DB.VwDepartmentCourseCount.FromSqlRaw("SELECT * FROM [dbo].[vwDepartmentCourseCount] where DepartmentID={0}",id).FirstOrDefault();
        }

        
    }
}