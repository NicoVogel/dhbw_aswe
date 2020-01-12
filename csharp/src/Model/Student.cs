using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvvm.Model
{
    public class Student : Person
    {
		public int Age { get; set; }
		public StudentCollection ClassBook { get; set; }
		public IList<double> Grades { get; set; }

		public Student(string name, DateTime birthday, GenderType gender, StudentCollection classBook, List<double> grades) : base(name, birthday, gender)
		{
			this.ClassBook = classBook;
			this.Grades = new List<double>(grades);
		}

		[JsonConstructor]
		public Student(string name, int age, GenderType gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
			this.Grades = new List<double>();
		}

		public Student(Student c_Student)
		{
			this.Name = c_Student.Name;
			this.Birthday = c_Student.Birthday;
			this.Age = c_Student.Age;
			this.Gender = c_Student.Gender;
			this.ClassBook = c_Student.ClassBook;
			this.Grades = new List<double>(c_Student.Grades);
		}

		public double GetAverageGrade()
		{
			return this.Grades.Average();
		}

		public void AddGrade(double grade)
		{
			this.Grades.Add(grade);
		}
	}
}
