using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    public class StudentViewModel : ViewModelBase
    {
		private Student _student;
		private IList<ClassBook> _classBooks;
		private ClassBook _selectedClass;
		private double _newGrade;	

		public ICommand AddGradeCommand { get; private set; }

		public StudentViewModel()
		{
			AddGradeCommand = new DelegateCommand(OnAddGrade);
		}

		private void OnAddGrade(object obj)
		{
			if(!Double.IsNaN(_newGrade))
			{
				_student.Grades.Add(_newGrade);
				_newGrade = 0;
				OnPropertyChanged(nameof(Student));
				OnPropertyChanged(nameof(NewGrade));
			}
		}

		public double NewGrade
		{
			get { return _newGrade; }
			set 
			{ 
				_newGrade = value;
				OnPropertyChanged(nameof(NewGrade));
			}
		}

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
