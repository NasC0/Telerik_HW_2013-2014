using System.Linq;
using System.Web.Http;
using StudentSystem.Data;
using StudentSystem.Model;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class HomeworkController : ApiController
    {
        private const string NoneExistingHomeworkID = "Bad request - Non existent homework ID.";
        private const string NonExistingCourseID = "Bad request - Non existent course ID.";
        private const string InvalidModel = "Bad request - invalid homework input paramateres.";
        private const string NonExistingStudentID = "Bad request - Non existent student ID.";

        private IStudentSystemData data;

        public HomeworkController()
            : this(new StudentSystemData())
        {
        }

        public HomeworkController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Homework()
        {
            var allHomework = this.data.Homeworks.GetAll().Select(HomeworkModel.FromHomework);
            return Ok(allHomework);
        }

        [HttpGet]
        public IHttpActionResult Homework(int id)
        {
            var homework = this.data.Homeworks.Find(h => h.HomeworkId == id).Select(HomeworkModel.FromHomework).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult AddHomework(HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var newHomework = new Homework
            {
                Content = homework.Content,
                TimeSent = homework.TimeSent,
                StudentID = homework.StudentID,
                CourseID = homework.CourseID
            };

            this.data.Homeworks.Add(newHomework);
            this.data.SaveChanges();
            homework.HomeworkID = newHomework.HomeworkId;

            return Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult ModifyHomework(int id, HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var homeworkToModify = this.data.Homeworks.Find(h => h.HomeworkId == id).FirstOrDefault();
            if (homeworkToModify == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            homeworkToModify.Content = homework.Content;
            homeworkToModify.TimeSent = homework.TimeSent;
            homeworkToModify.CourseID = homework.CourseID;
            homeworkToModify.StudentID = homework.StudentID;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteHomework(int id)
        {
            var homeworkToDelete = this.data.Homeworks.Find(h => h.HomeworkId == id).FirstOrDefault();
            if (homeworkToDelete == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            this.data.Homeworks.Remove(homeworkToDelete);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCourse(int id)
        {
            var homework = this.data.Homeworks.Find(h => h.HomeworkId == id).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            var course = homework.Course;

            return Ok(new CourseModel
            {
                CourseID = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Materials = course.Materials
            });
        }

        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var homework = this.data.Homeworks.Find(h => h.HomeworkId == id).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            var student = homework.Student;

            return Ok(new StudentModel
            {
                StudentID = student.StudentId,
                Name = student.Name,
                FNumber = student.FNumber
            });
        }

        [HttpPut]
        public IHttpActionResult ChangeCourse(int id, int courseID)
        {
            var homework = this.data.Homeworks.Find(h => h.HomeworkId == id).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            var course = this.data.Courses.Find(c => c.CourseId == courseID).FirstOrDefault();
            if (course == null)
            {
                return BadRequest(NonExistingCourseID);
            }

            homework.Course = course;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult ChangeStudent(int id, int studentID)
        {
            var homework = this.data.Homeworks.Find(h => h.HomeworkId == id).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest(NoneExistingHomeworkID);
            }

            var student = this.data.Students.Find(s => s.StudentId == studentID).FirstOrDefault();
            if (student == null)
            {
                return BadRequest(NonExistingStudentID);
            }

            homework.Student = student;
            this.data.SaveChanges();

            return Ok();
        }
    }
}
