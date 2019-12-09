using mvvm.Model;
using mvvm.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.ViewModel
{
    public class StudentViewModel
    {
        public StudentCollection ClassBook { get; }

        public StudentViewModel()
        {
            ClassBook = StudentTestDataUtility.GetStudentTestData();
        }
    }
}
