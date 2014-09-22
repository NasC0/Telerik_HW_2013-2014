using System.Linq;
using System.Web.Http;
using StudentSystem.Data;
using StudentSystem.Model;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {

        private const string NonExistingStudentID = "Bad request - Non existent student ID.";
        private const string NonExistingCourseID = "Bad request - Non existent course ID.";
        private const string InvalidModel = "Bad request - invalid student input paramateres.";

        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentSystemData())
        {
        }
        
        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Students()
        {
            var students = this.data.Students.GetAll().Select(StudentModel.FromStudent);

            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult Students(int id)
        {
            var student = this.data.Students.Find(s => s.StudentId == id).Select(StudentModel.FromStudent).FirstOrDefault();
            if (student == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult AddStudent(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var newStudent = new Student
            {
                Name = student.Name,
                FNumber = student.FNumber
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();
            student.StudentID = newStudent.StudentId;

            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult ModifyStudent(int id, StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var studentToModify = this.data.Students.Find(s => s.StudentId == id).FirstOrDefault();
            if (studentToModify == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            studentToModify.FNumber = student.FNumber;
            studentToModify.Name = student.Name;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var studentToDelete = this.data.Students.Find(s => s.StudentId == id).FirstOrDefault();
            if (studentToDelete == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            this.data.Students.Remove(studentToDelete);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AddCourse(int id, int courseID)
        {
            var studentToAdd = this.data.Students.Find(s => s.StudentId == id).FirstOrDefault();
            if (studentToAdd == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            var course = this.data.Courses.Find(c => c.CourseId == courseID).FirstOrDefault();
            if (course == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            course.Students.Add(studentToAdd);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCourses(int id)
        {
            var student = this.data.Students.Find(c => c.StudentId == id).FirstOrDefault();
            if (student == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            var coursesInStudent = student.Courses.AsQueryable().Select(CourseModel.FromCourse);

            return Ok(coursesInStudent);
        }

        [HttpGet]
        public IHttpActionResult GetHomeworks(int id)
        {
            var student = this.data.Students.Find(c => c.StudentId == id).FirstOrDefault();
            if (student == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            var homeworksInCourse = student.Homeworks.AsQueryable().Select(HomeworkModel.FromHomework);
            return Ok(homeworksInCourse);
        }
    }
}
