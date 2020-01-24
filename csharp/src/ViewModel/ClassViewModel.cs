using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    public class ClassViewModel : ViewModelBase
    {
        private ClassBook _classBook;
        private ObservableCollection<Teacher> _teachers;
        private Student _selectedStudent;

        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get 
            { 
                return _students; 
            }
        }


        public ICommand AddStudentCommand { get; private set; }
        public ICommand OpenStudentCommand { get; private set; }
        public ICommand DeleteStudentCommand { get; private set; }

        public ClassViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddStudentCommand = new DelegateCommand(OnAddStudent);
            OpenStudentCommand = new DelegateCommand(OnOpenStudent);
            DeleteStudentCommand = new DelegateCommand(OnDeleteStudent);
        }

        private void OnDeleteStudent()
        {
            if (SelectedStudent == null)
            {
                return;
            }
            _classBook.Students.Remove(_selectedStudent);
            _students.Remove(_selectedStudent);
        }

        private void OnOpenStudent()
        {
            throw new NotImplementedException();
        }

        private void OnAddStudent()
        {
            throw new NotImplementedException();
        }

        public Student SelectedStudent
        {
            get 
            {
                return _selectedStudent; 
            }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
        public ClassBook ClassBook
        {
            get
            {
                return _classBook;
            }
            set
            {
                _classBook = value;
                _students = new ObservableCollection<Student>(_classBook.Students);
                OnPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                return _teachers;
            }
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }
    }
}