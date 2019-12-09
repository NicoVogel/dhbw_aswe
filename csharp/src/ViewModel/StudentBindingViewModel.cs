using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.ViewModel
{
    public class StudentBindingViewModel
    {
        public StudentCollection ClassBook { get; }
        public Student SelectedStudent { get; set; }

        public StudentBindingViewModel()
        {
            ClassBook = new StudentCollection();
        }
    }
}
