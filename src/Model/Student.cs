using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Student
    {
		private string m_Name;
		private int m_Age;
		private GenterType m_Gender;

		public Student(string name, int age, GenterType gender)
		{
			m_Name = name;
			m_Age = age;
			m_Gender = gender;
		}

		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public int Age
		{
			get { return m_Age; }
			set { m_Age = value; }
		}

		public GenterType Gender
		{
			get { return m_Gender; }
			set { m_Gender = value; }
		}
	}
}
