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
        public static StudentCollection GetStudentTestData()
        {
            StudentCollection result = new StudentCollection();
            foreach (Student student in JsonConvert.DeserializeObject<Student[]>(Resources.JsonData))
            {
                result.Students.Add(student);
            }
            return result;
        }

        public static void FillStudentTestData(StudentCollection studentCollection)
        {
            if (studentCollection is null)
            {
                return;
            }

            studentCollection.Students.Clear();
            foreach(Student student in JsonConvert.DeserializeObject<Student[]>(Resources.JsonData))
            {
                studentCollection.Students.Add(student);
            }
        }
    }
}
