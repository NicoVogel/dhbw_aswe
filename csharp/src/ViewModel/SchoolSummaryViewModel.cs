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
        public ObservableCollection<ClassBook> ClassBooks { get; set; }
        public ClassBook SelectedClass { get; set; }
        public ClassBook NewClass { get; set; }

        public bool NewClassDialogVisible { get; private set; } = false;

        public ObservableCollection<Teacher> Teachers { get; set; }

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
            throw new NotImplementedException();
        }

        private void OnAddClass(object obj)
        {
            NewClass = new ClassBook();
            NewClassDialogVisible = true;
            OnPropertyChanged(nameof(NewClassDialogVisible));
        }

        public void UpdateClassBooks(IList<ClassBook> classBooks)
        {
            this.ClassBooks = new ObservableCollection<ClassBook>(classBooks);
            OnPropertyChanged(nameof(ClassBooks));
        }

        internal void UpdateTeachers(IList<Teacher> teachers)
        {
            this.Teachers = new ObservableCollection<Teacher>(teachers);
            OnPropertyChanged(nameof(Teachers));
        }
    }
}
