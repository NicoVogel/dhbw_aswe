using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.ViewModel
{
    public class StudentViewModel
    {
        public ClassBook ClassBook { get; }

        public StudentViewModel()
        {
            ClassBook = StudentTestDataUtility.GetStudentTestData();
        }
    }
}
