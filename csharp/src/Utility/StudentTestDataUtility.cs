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
        public static DummySchoolData GetDummySchoolData()
        {
            var result = new DummySchoolData();

            IList<ClassBook> classBooks = new List<ClassBook>();
            IList<Teacher> teachers = new List<Teacher>();
            IList<Student> students = new List<Student>();

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

            classBooks.Add(classBook_1);
            classBooks.Add(classBook_2);
            classBooks.Add(classBook_3);

            teachers.Add(teacher_1);
            teachers.Add(teacher_2);
            teachers.Add(teacher_3);

            foreach(var student in students_1) {
                students.Add(student);
            }
            foreach(var student in students_2) {
                students.Add(student);
            }
            foreach(var student in students_3) {
                students.Add(student);
            }

            result.ClassBooks = classBooks;
            result.Teachers = teachers;
            result.Students = students;

            return result;
        }
    }
}
