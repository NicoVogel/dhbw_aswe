using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                EnrollStudent(classBook, student);
            }
        }

        internal static void EnrollStudent(ClassBook classBook, Student student)
        {
            if (student.ClassBook != null)
            {
                student.ClassBook.Students.Remove(student);     // remove student from old class
            }
            classBook.Students.Add(student);                    // add student to new class
            student.ClassBook = classBook;
        }
    }
}
