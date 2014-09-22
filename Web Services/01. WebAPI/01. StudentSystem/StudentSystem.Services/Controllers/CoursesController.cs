using System.Linq;
using System.Web.Http;
using StudentSystem.Data;
using StudentSystem.Model;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class CoursesController : ApiController
    {
        private const string NonExistingCourseID = "Bad request - Non existent course ID.";
        private const string InvalidModel = "Bad request - invalid course input paramateres.";
        private const string NonExistingStudentID = "Bad request - Non existent student ID.";

        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Courses()
        {
            var courses = this.data.Courses.GetAll().Select(CourseModel.FromCourse);
            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult Courses(int id)
        {
            var course = this.data.Courses.Find(c => c.CourseId == id).Select(CourseModel.FromCourse).FirstOrDefault();
            if (course == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult AddCourse(CourseModel course)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var newCourse = new Course
            {
                Description = course.Description,
                Materials = course.Materials,
                Name = course.Name
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();
            course.CourseID = newCourse.CourseId;

            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult ModifyCourse(int id, CourseModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var courseToUpdate = this.data.Courses.Find(c => c.CourseId == id).FirstOrDefault();
            if (courseToUpdate == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            courseToUpdate.Description = course.Description;
            courseToUpdate.Materials = course.Materials;
            courseToUpdate.Name = course.Name;

            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCourse(int id)
        {
            var courseToDelete = this.data.Courses.Find(c => c.CourseId == id).FirstOrDefault();
            if (courseToDelete == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            var courseToReturn = new CourseModel
            {
                Name = courseToDelete.Name,
                Materials = courseToDelete.Materials,
                Description = courseToDelete.Description,
                CourseID = courseToDelete.CourseId
            };

            this.data.Courses.Remove(courseToDelete);
            this.data.SaveChanges();

            return Ok(courseToReturn);
        }

        [HttpPut]
        public IHttpActionResult AddStudent(int courseID, int studentID)
        {
            var studentToAdd = this.data.Students.Find(s => s.StudentId == studentID).FirstOrDefault();
            if (studentToAdd == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            var course = this.data.Courses.Find(c => c.CourseId == courseID).FirstOrDefault();
            if (course == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            course.Students.Add(studentToAdd);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetStudents(int id)
        {
            var course = this.data.Courses.Find(c => c.CourseId == id).FirstOrDefault();
            if (course == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            var studentsInCourse = course.Students.AsQueryable().Select(StudentModel.FromStudent);

            return Ok(studentsInCourse);
        }

        [HttpGet]
        public IHttpActionResult GetHomeworks(int id)
        {
            var course = this.data.Courses.Find(c => c.CourseId == id).FirstOrDefault();
            if (course == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            var homeworksInCourse = course.Homeworks.AsQueryable().Select(HomeworkModel.FromHomework);
            return Ok(homeworksInCourse);
        }
    }
}
