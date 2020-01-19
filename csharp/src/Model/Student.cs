using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvvm.Model
{
    public class Student : Person
    {
		public ClassBook ClassBook { get; set; }
		public IList<double> Grades { get; set; }

		public Student(string name, DateTime birthday, GenderType gender, ClassBook classBook, IList<double> grades) : base(name, birthday, gender)
		{
			this.ClassBook = classBook;
			this.Grades = grades;
		}

		[JsonConstructor]
		public Student(string name, string birthday, GenderType gender) : base(name, birthday, gender)
		{
			this.Grades = new List<double>();
		}

		public Student(string name, DateTime birthday, GenderType gender, ClassBook classBook, List<double> grades) : base(name, birthday, gender)
		{
			this.ClassBook = classBook;
			this.Grades = new List<double>(grades);
		}

		public Student(Student c_Student) : base(c_Student.Name, c_Student.Birthday, c_Student.Gender)
		{
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
