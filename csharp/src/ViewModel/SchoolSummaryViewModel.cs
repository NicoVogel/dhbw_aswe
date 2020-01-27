using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
        public ClassBook SelectedClass { get; set; }

        public bool NewClassDialogVisible { get; private set; } = false;
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

        public SchoolSummaryViewModel()
        {
            ClassBooks = new ObservableCollection<ClassBook>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddClassCommand = new DelegateCommand(OnAddClass);
            OpenClassCommand = new DelegateCommand(OnOpenClass);
            DeleteClassCommand = new DelegateCommand(OnDeleteClass);
            CancelAddClassCommand = new DelegateCommand(OnCancelAddClass);
            SubmitAddClassCommand = new DelegateCommand(OnSubmitAddClass);
        }

        private void OnAddClass(object obj)
        {
            NewClass = new ClassBook();
            NewClassDialogVisible = true;
            OnPropertyChanged(nameof(NewClassDialogVisible));
        }

        internal void Update()
        {
            //Workaround for forcing datagrid to update
            ClassBooks = new ObservableCollection<ClassBook>(ClassBooks);
            OnPropertyChanged(nameof(ClassBooks));
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
