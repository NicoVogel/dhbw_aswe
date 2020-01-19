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

        public ICommand AddClassCommand { get; private set; }
        public ICommand OpenClassCommand { get; private set; }
        public ICommand DeleteClassCommand { get; private set; }

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
            throw new NotImplementedException();
        }

        public void UpdateClassBooks(IList<ClassBook> classBooks)
        {
            this.ClassBooks = new ObservableCollection<ClassBook>(classBooks);
            OnPropertyChanged(nameof(ClassBooks));
        }
    }
}
