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

            ClassBook.Students.Remove(SelectedStudent);
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
                OnPropertyChanged(nameof(ClassBook));
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