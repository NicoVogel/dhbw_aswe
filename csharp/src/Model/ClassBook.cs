using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvvm.Model
{
    public class ClassBook
    {
        public string Name { get; set; }
        public Teacher Teacher { get; private set; }
        public ISet<Student> Students { get; }
        public IList<Student> FullAgeStudents
        {
            get
            {
                return this.Students.Where(x => x.Age >= 18).ToList();
            }
        }

        [JsonConstructor]
        public ClassBook(string name)
        {
            this.Name = name;
            this.Students = new HashSet<Student>();
        }

        public ClassBook()
        {
            Students = new HashSet<Student>();
        }

        internal void HireTeacher(Teacher teacher)
        {
            this.Teacher = teacher;
            teacher.AssignClass(this);
        }

        internal void EnrollStudents(IList<Student> students)
        {
            foreach (Student student in students)
            {
                this.Students.Add(student);
                student.ClassBook = this;
            }
        }
    }
}
