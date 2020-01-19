using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Utility
{
    class SchoolUtil
    {
        public static void AssignClass(Teacher teacher, ClassBook classBook)
        {
            teacher.ClassBooks.Add(classBook);
        }

        public static void HireTeacher(ClassBook classBook, Teacher teacher)
        {
            classBook.Teacher = teacher;
            AssignClass(teacher, classBook);
        }

        public static void EnrollStudents(ClassBook classBook, IList<Student> students)
        {
            foreach (Student student in students)
            {
                classBook.Students.Add(student);
                student.ClassBook = classBook;
            }
        }
    }
}
