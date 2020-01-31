using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    class SchoolSummaryViewModel : ViewModelBase
    {
        //Reference to MainViewModel
        public MainViewModel MainViewModel { get; set; }

        private ObservableCollection<ClassBook> _classBooks;
        private ObservableCollection<Teacher> _teachers;
        private ClassBook _newClass;
        private Teacher _newTeacher;
        public ClassBook SelectedClass { get; set; }
        public Teacher SelectedTeacher { get; set; }

        public bool NewClassDialogVisible { get; private set; } = false;
        public bool NewTeacherDialogVisible { get; private set; } = false;

        public Teacher NewTeacher
        {
            get { return _newTeacher; }
            set 
            { 
                _newTeacher = value;
                OnPropertyChanged(nameof(NewTeacher));
            }
        }
        public ObservableCollection<ClassBook> ClassBooks
        {
            get
            {
                return _classBooks;
            }
            set
            {
                _classBooks = value;
                OnPropertyChanged(nameof(ClassBooks));
            }
        }
        public ClassBook NewClass
        {
            get
            {
                return _newClass;
            }
            set
            {
                _newClass = value;
                OnPropertyChanged(nameof(NewClass));
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

        public ICommand AddClassCommand { get; private set; }
        public ICommand OpenClassCommand { get; private set; }
        public ICommand DeleteClassCommand { get; private set; }
        public ICommand CancelAddClassCommand { get; private set; }
        public ICommand SubmitAddClassCommand { get; private set; }
        public ICommand AddTeacherCommand { get; private set; }
        public ICommand SubmitAddTeacherCommand { get; private set; }
        public ICommand CancelAddTeacherCommand { get; private set; }
        public ICommand OpenTeacherCommand { get; private set; }
        public ICommand DeleteTeacherCommand { get; private set; }

        public SchoolSummaryViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddClassCommand = new DelegateCommand(OnAddClass);
            OpenClassCommand = new DelegateCommand(OnOpenClass);
            DeleteClassCommand = new DelegateCommand(OnDeleteClass);
            CancelAddClassCommand = new DelegateCommand(OnCancelAddClass);
            SubmitAddClassCommand = new DelegateCommand(OnSubmitAddClass);
            AddTeacherCommand = new DelegateCommand(OnAddTeacher);
            SubmitAddTeacherCommand = new DelegateCommand(OnSubmitAddTeacher);
            CancelAddTeacherCommand = new DelegateCommand(OnCancelAddTeacher);
            OpenTeacherCommand = new DelegateCommand(OnOpenTeacher);
            DeleteTeacherCommand = new DelegateCommand(OnDeleteTeacher);
        }

        private void OnDeleteTeacher(object obj)
        {
            if(SelectedTeacher == null)
            {
                return;
            }
            if(Teachers.Count <= 1)
            {
                MessageBox.Show("There must be at least one teacher employed");
                return;
            }
            var classBooks = SelectedTeacher.ClassBooks;
            Teachers.Remove(SelectedTeacher);
            SelectedTeacher = null;
            foreach(var classBook in classBooks)
            {
                SchoolUtil.HireTeacher(classBook, Teachers[0]);
            }

            Update();
        }

        private void OnOpenTeacher(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnCancelAddTeacher(object obj)
        {
            NewTeacherDialogVisible = false;
            OnPropertyChanged(nameof(NewTeacherDialogVisible));
        }

        private void OnSubmitAddTeacher(object obj)
        {
            Teachers.Add(NewTeacher);
            OnPropertyChanged(nameof(Teachers));
            NewTeacherDialogVisible = false;
            OnPropertyChanged(nameof(NewTeacherDialogVisible));
        }

        private void OnAddTeacher(object obj)
        {
            NewTeacher = new Teacher();
            NewTeacherDialogVisible = true;
            OnPropertyChanged(nameof(NewTeacherDialogVisible));
        }

        private void OnAddClass(object obj)
        {
            NewClass = new ClassBook();
            NewClassDialogVisible = true;
            OnPropertyChanged(nameof(NewClassDialogVisible));
        }

        internal void Update()
        {
            //Workaround for forcing datagrids to update
            ClassBooks = new ObservableCollection<ClassBook>(ClassBooks);
            OnPropertyChanged(nameof(ClassBooks));
            Teachers = new ObservableCollection<Teacher>(Teachers);
            OnPropertyChanged(nameof(Teachers));
        }

        private void OnSubmitAddClass(object obj)
        {
            ClassBooks.Add(NewClass);
            OnPropertyChanged(nameof(ClassBooks));
            NewClassDialogVisible = false;
            OnPropertyChanged(nameof(NewClassDialogVisible));
        }

        private void OnCancelAddClass(object obj)
        {
            NewClassDialogVisible = false;
            OnPropertyChanged(nameof(NewClassDialogVisible));
        }

        private void OnDeleteClass(object obj)
        {
            if(SelectedClass == null)
            {
                return;
            }
            ClassBooks.Remove(SelectedClass);
            OnPropertyChanged(nameof(ClassBooks));
        }

        private void OnOpenClass(object obj)
        {
            if(SelectedClass != null)
            {
                MainViewModel.OnClassView(SelectedClass);
            }
        }
    }
}
