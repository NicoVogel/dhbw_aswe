using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    public class StudentBindingViewModel : INotifyPropertyChanged
    {
        public StudentCollection ClassBook { get; }
        public ObservableCollection<Student> Students { get; private set; }
        private Student m_SelectedStudent = null;
        public Student SelectedStudent
        {
            get
            {
                return m_SelectedStudent;
            }
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

        public ICommand DeleteStudentCommand { get; private set; }

        public StudentBindingViewModel()
        {
            ClassBook = StudentTestDataUtility.GetStudentTestData();
            DeleteStudentCommand = new DelegateCommand(OnDeleteStudent);
            Students = new ObservableCollection<Student>(ClassBook.Students);
        }

        private void OnDeleteStudent(object obj)
        {
            if(SelectedStudent == null) 
            {
                return;
            }
            Students.Remove(SelectedStudent);
            OnPropertyChanged(nameof(ClassBook.Students));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
