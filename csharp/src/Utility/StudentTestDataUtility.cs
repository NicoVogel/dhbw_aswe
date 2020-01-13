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
