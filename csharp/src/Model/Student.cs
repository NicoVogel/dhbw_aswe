using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Student
    {
		public string Name { get; set; }
		public int Age { get; set; }
		public GenderType Gender { get; set; }

		[JsonConstructor]
		public Student(string name, int age, GenderType gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}

		public Student(Student c_Student)
		{
			this.Name = c_Student.Name;
			this.Age = c_Student.Age;
			this.Gender = c_Student.Gender;
		}
	}
}
