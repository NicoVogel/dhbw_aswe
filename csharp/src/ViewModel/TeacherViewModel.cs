using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mvvm.ViewModel
{
    public class TeacherViewModel : ViewModelBase
    {
		private Teacher _teacher;
		private ObservableCollection<ClassBook> _classBooks;
		public IList<ClassBook> AllClasses { get; set; } = new List<ClassBook>();

		public ObservableCollection<ClassBook> ClassBooks
		{
			get { return _classBooks; }
			set 
			{
				_classBooks = value;
				OnPropertyChanged(nameof(ClassBooks));
			}
		}

		public Teacher Teacher
		{
			get { return _teacher; }
			set
			{
				_teacher = value;
				ClassBooks = new ObservableCollection<ClassBook>(_teacher.ClassBooks);
				OnPropertyChanged(nameof(Teacher));
			}
		}

	}
}
