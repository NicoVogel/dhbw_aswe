using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    class Student
    {
		private String m_Name;
		private int m_Age;

		public int Age
		{
			get { return m_Age; }
			set { m_Age = value; }
		}


		public String Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

	}
}
