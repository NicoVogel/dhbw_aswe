using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class DummySchoolData
    {
        public IList<ClassBook> ClassBooks { get; set; }
        public IList<Teacher> Teachers { get; set; }
        public IList<Student> Students { get; set; }
    }
}
