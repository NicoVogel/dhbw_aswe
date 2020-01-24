using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.ViewModel
{
    public class StudentViewModel : ViewModelBase
    {
		private Student _student;
		private IList<ClassBook> _classBooks;

		public IList<ClassBook> ClassBooks
		{
			get { return _classBooks; }
			set { _classBooks = value; }
		}


		public Student Student
		{
			get { return _student; }
			set 
			{ 
				_student = value;
				OnPropertyChanged(nameof(Student));
			}
		}

	}
}
