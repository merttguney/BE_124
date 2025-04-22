using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly List<Student> _students = new();

        [HttpGet]
        public IEnumerable<Student> GetList()
        {
            return _students;
        }

        [HttpGet("{id}")]
        public Student? GetStudent(int id)
        {
            return _students.Find(x => x.Id == id);
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            student.Id = _students.Count + 1;
            _students.Add(student);
        }

        //[HttpPut("{id}")]
        //public void UpdateStudent(int id, Student student)
        //{
        //    var index = _students.FindIndex(x => x.Id == id);

        //    if (index == -1)
        //    {
        //        return; // early return
        //    }

        //    _students[index].FirstName = student.FirstName;
        //    _students[index].LastName = student.LastName;

        //}

        [HttpPut("{id}")]
        public void UpdateStudent(int id, string firstName, string lastName)
        {
            var index = _students.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return; // early return
            }

            _students[index].FirstName = firstName;
            _students[index].LastName = lastName;

        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            var index = _students.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return; // early return
            }
            _students.RemoveAt(index);
        }


    }
}
