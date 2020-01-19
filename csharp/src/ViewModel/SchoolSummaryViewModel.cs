using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mvvm.ViewModel
{
    class SchoolSummaryViewModel : ViewModelBase
    {
        public ObservableCollection<ClassBook> ClassBooks { get; set; }

        public SchoolSummaryViewModel()
        {
            ClassBooks = new ObservableCollection<ClassBook>();
        }

        public void UpdateClassBooks(IList<ClassBook> classBooks)
        {
            this.ClassBooks = new ObservableCollection<ClassBook>(classBooks);
            OnPropertyChanged(nameof(ClassBooks));
        }
    }
}
