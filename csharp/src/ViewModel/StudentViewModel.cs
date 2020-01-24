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
		private ClassBook _selectedClass;

		public ClassBook SelectedClass
		{
			get { return _selectedClass; }
			set
			{
				_selectedClass = value;
				SchoolUtil.EnrollStudent(SelectedClass, Student);
				OnPropertyChanged(nameof(SelectedClass));
			}
		}

		public IList<ClassBook> ClassBooks
		{
			get { return _classBooks; }
			set 
			{ 
				_classBooks = value;
				OnPropertyChanged(nameof(ClassBooks));
			}
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
