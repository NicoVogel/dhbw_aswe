using mvvm.Model;
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
    public class MainVIewModel : ViewModelBase
    {
        private UserControl SchoolSummaryView { get; }
        private UserControl ClassView { get; }
        private UserControl TeacherView { get; }
        private UserControl StudentView { get; }
        public UserControl CurrentView { get; set; }

        public MainVIewModel()
        {
            SchoolSummaryView = new SchoolSummaryView();
            ClassView = new ClassView();
            TeacherView = new TeacherView();
            StudentView = new StudentView();

            CurrentView = SchoolSummaryView;
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
