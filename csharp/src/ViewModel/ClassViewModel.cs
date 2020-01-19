using mvvm.Model;
using System.Collections.ObjectModel;

namespace mvvm.ViewModel
{
    public class ClassViewModel : ViewModelBase
    {
        private ClassBook _classBook;
        private ObservableCollection<Teacher> _teachers;

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