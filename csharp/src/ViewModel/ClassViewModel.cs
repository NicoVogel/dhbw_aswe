using Microsoft.VisualStudio.PlatformUI;
using mvvm.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    public class ClassViewModel : ViewModelBase
    {
        private ClassBook _classBook;
        private ObservableCollection<Teacher> _teachers;
        private string _ChangeCancelButtonText;
        private bool _isChangeTeacher;

        public ICommand ChangeCancelCommand { get; private set; }

        public ClassViewModel()
        {
            ChangeCancelCommand = new DelegateCommand(OnChangeCancelTeacher);
            IsChangeTeacher = false;
            UpdateChangeCancelButtonText();
        }

        private void OnChangeCancelTeacher()
        {
            IsChangeTeacher = !IsChangeTeacher;
            UpdateChangeCancelButtonText();
        }

        private void UpdateChangeCancelButtonText()
        {
            if(IsChangeTeacher)
            {
                ChangeCancelButtonText = "Cancel";
            }
            else
            {
                ChangeCancelButtonText = "Change";
            }
            OnPropertyChanged(nameof(ChangeCancelButtonText));

        }

        public bool IsChangeTeacher
        {
            get
            {
                return _isChangeTeacher; 
            }
            set
            {
                _isChangeTeacher = value;
                OnPropertyChanged(nameof(IsChangeTeacher));
            }
        }

        public string ChangeCancelButtonText
        {
            get 
            { 
                return _ChangeCancelButtonText; 
            }
            set 
            {
                _ChangeCancelButtonText = value;
                OnPropertyChanged(nameof(ChangeCancelButtonText));
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
    }
}