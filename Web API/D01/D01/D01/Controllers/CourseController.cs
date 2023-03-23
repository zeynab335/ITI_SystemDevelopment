using D01.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace D01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            var courses = CoursesList.Courses.ToList();
            if (courses.Count > 0)
            {
                return Ok(courses);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            var course = CoursesList.Courses.Find(c => c.Id == id);

            if (course != null)
            {
                return Ok(course);
            }
            else
            {   
                return NotFound();
            }
        }

        
        [HttpGet("{name:alpha}")]
        public IActionResult couseByName(string name )
        {
            var course = CoursesList.Courses.Find(c => c.Name == name);

            if (course != null)
            {
                return Ok(course);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult deleteCourse(int id)
        {
            var course = CoursesList.Courses.Find(c => c.Id == id);
            if (course != null)
            {
                CoursesList.Courses.Remove(course);     
                return Ok(course);  
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult post(Course c)
        {


            if (c != null)
            {
                CoursesList.Courses.Add(c);
                return CreatedAtAction(nameof(post), c);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        public IActionResult put(int id , Course c)
        {

            if(id != c.Id)
            {
                // status code ==> 400
                return BadRequest();
            }
            else 
            {
                var course = CoursesList.Courses.Find(c => c.Id == id);
                if (course == null) return NotFound();
                else
                {
                    course.Duration = c.Duration;
                    course.Name = c.Name;
                    course.Description = c.Description;

                    return NoContent(); // 204 status code
                }

            }
            
        }


    }
}
