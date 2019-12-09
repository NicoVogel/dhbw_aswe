using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace mvvm.ViewModel
{
    public class StudentBindingViewModel : INotifyPropertyChanged
    {
        public StudentCollection ClassBook { get; }
        private Student m_SelectedStudent;

        public Student SelectedStudent
        {
            get { return m_SelectedStudent; }
            set 
            {
                if(m_SelectedStudent == value)
                {
                    return;
                }
                m_SelectedStudent = value;
                OnPropertyChanged();
            }
        }


        public StudentBindingViewModel()
        {
            ClassBook = StudentTestDataUtility.GetStudentTestData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
