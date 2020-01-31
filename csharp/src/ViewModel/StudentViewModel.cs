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
				var oldClass = _selectedClass;
				_selectedClass = value;
				SchoolUtil.EnrollStudent(_selectedClass, _student);
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
				_selectedClass = _student.ClassBook;
				OnPropertyChanged(nameof(SelectedClass));
				OnPropertyChanged(nameof(Student));
			}
		}

	}
}
