using mvvm.Model;
using mvvm.Utility;
using mvvm.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace mvvm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private UserControl SchoolSummaryView { get; }
        private UserControl ClassView { get; }
        private UserControl TeacherView { get; }
        private UserControl StudentView { get; }
        public UserControl CurrentView { get; set; }

        private SchoolSummaryViewModel SchoolSummaryViewModel;
        private ClassViewModel ClassViewModel;
        private TeacherViewModel TeacherViewModel;
        private StudentViewModel StudentViewModel;

        public IList<ClassBook> ClassBooks { get; set; }

        public MainViewModel()
        {
            SchoolSummaryView = new SchoolSummaryView();
            ClassView = new ClassView();
            TeacherView = new TeacherView();
            StudentView = new StudentView();

            SchoolSummaryViewModel = (SchoolSummaryViewModel)SchoolSummaryView.DataContext;
            ClassViewModel = (ClassViewModel)ClassView.DataContext;
            TeacherViewModel = (TeacherViewModel)TeacherView.DataContext;
            StudentViewModel = (StudentViewModel)StudentView.DataContext;

            ClassBooks = StudentTestDataUtility.GetDummyClassBookData();

            OnSchoolSummaryView();
        }

        private void OnSchoolSummaryView()
        {
            SchoolSummaryViewModel.UpdateClassBooks(this.ClassBooks);
            CurrentView = SchoolSummaryView;
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
