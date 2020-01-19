using mvvm.Model;
using mvvm.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Utility
{
    public class StudentTestDataUtility
    {
        public static IList<ClassBook> GetDummyClassBookData()
        {
            ClassBook classBook_1 = JsonConvert.DeserializeObject<ClassBook>(Resources.Class_1);
            ClassBook classBook_2 = JsonConvert.DeserializeObject<ClassBook>(Resources.Class_2);
            ClassBook classBook_3 = JsonConvert.DeserializeObject<ClassBook>(Resources.Class_3);

            Teacher teacher_1 = JsonConvert.DeserializeObject<Teacher>(Resources.Teacher_1);
            Teacher teacher_2 = JsonConvert.DeserializeObject<Teacher>(Resources.Teacher_2);
            Teacher teacher_3 = JsonConvert.DeserializeObject<Teacher>(Resources.Teacher_3);

            IList<Student> students_1 = JsonConvert.DeserializeObject<Student[]>(Resources.Students_1);
            IList<Student> students_2 = JsonConvert.DeserializeObject<Student[]>(Resources.Students_2);
            IList<Student> students_3 = JsonConvert.DeserializeObject<Student[]>(Resources.Students_3);

            SchoolUtil.HireTeacher(classBook_1, teacher_1);
            SchoolUtil.HireTeacher(classBook_2, teacher_2);
            SchoolUtil.HireTeacher(classBook_3, teacher_3);

            SchoolUtil.EnrollStudents(classBook_1, students_1);
            SchoolUtil.EnrollStudents(classBook_2, students_2);
            SchoolUtil.EnrollStudents(classBook_3, students_3);

            return new List<ClassBook> { classBook_1, classBook_2, classBook_3 };
        }

        public static ClassBook GetStudentTestData()
        {
            ClassBook result = new ClassBook();
            foreach (Student student in JsonConvert.DeserializeObject<Student[]>(Resources.Students_1))
            {
                result.Students.Add(student);
            }
            return result;
        }

        public static void FillStudentTestData(ClassBook studentCollection)
        {
            if (studentCollection is null)
            {
                return;
            }

            studentCollection.Students.Clear();
            foreach(Student student in JsonConvert.DeserializeObject<Student[]>(Resources.Students_1))
            {
                studentCollection.Students.Add(student);
            }
        }
    }
}
