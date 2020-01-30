using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    public class ClassViewModel : ViewModelBase
    {
        //Reference to MainViewModel
        public MainViewModel MainViewModel { get; set; }

        private ClassBook _classBook;
        private ObservableCollection<Teacher> _teachers;
        private Student _selectedStudent;
        public bool NewStudentDialogVisible { get; private set; } = false;
        private Student _newStudent;
        private Teacher _selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set 
            { 
                _selectedTeacher = value;
                SchoolUtil.HireTeacher(_classBook, _selectedTeacher);
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }


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
        public ICommand CancelNewStudentCommand { get; private set; }
        public ICommand SubmitNewStudentCommand { get; private set; }


        public ClassViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddStudentCommand = new DelegateCommand(OnAddStudent);
            OpenStudentCommand = new DelegateCommand(OnOpenStudent);
            DeleteStudentCommand = new DelegateCommand(OnDeleteStudent);
            CancelNewStudentCommand = new DelegateCommand(OnCancelNewStudent);
            SubmitNewStudentCommand = new DelegateCommand(OnSubmitNewStudent);
        }

        private void OnSubmitNewStudent(object obj)
        {
            Students.Add(NewStudent);   // add to observable collection
            SchoolUtil.EnrollStudent(ClassBook, NewStudent); // create bidirectional connection class <--> student
            NewStudentDialogVisible = false;
            OnPropertyChanged(nameof(NewStudentDialogVisible));
        }

        private void OnCancelNewStudent(object obj)
        {
            NewStudentDialogVisible = false;
            OnPropertyChanged(nameof(NewStudentDialogVisible));
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
            if(SelectedStudent != null)
            {
                MainViewModel.OnStudentView(SelectedStudent);
            }
        }

        private void OnAddStudent()
        {
            NewStudent = new Student();
            NewStudentDialogVisible = true;
            OnPropertyChanged(nameof(NewStudentDialogVisible));
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
                SelectedTeacher = _classBook.Teacher;
                OnPropertyChanged(nameof(Students));
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
        public Student NewStudent
        {
            get 
            {
                return _newStudent; 
            }
            set
            {
                _newStudent = value;
                OnPropertyChanged(nameof(NewStudent));
            }
        }
    }
}