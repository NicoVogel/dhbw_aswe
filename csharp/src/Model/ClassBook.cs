using mvvm.ViewModel;
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
        public Teacher Teacher { get; set; }
        public IList<Student> Students { get; }
        public IList<Student> FullAgeStudents
        {
            get
            {
                return this.Students.Where(x => x.Age >= 18).ToList();
            }
        }

        public ClassBook(String name, Teacher teacher, IList<Student> students)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Students = students;
        }

        [JsonConstructor]
        public ClassBook(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        public ClassBook()
        {
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
