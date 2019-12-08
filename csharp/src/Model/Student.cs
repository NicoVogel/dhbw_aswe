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

		public Student(string name, int age, GenderType gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}
	}
}
