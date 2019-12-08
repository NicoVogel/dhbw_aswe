using mvvm.Model;
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
            ClassBook = new StudentCollection();
            ClassBook.Students.Add(new Student("Andi Theke", 19, GenderType.Male));
        }
    }
}
