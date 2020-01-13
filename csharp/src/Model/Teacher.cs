using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Teacher : Person
    {
        public ISet<ClassBook> Classes { get; private set; }

        [JsonConstructor]
        public Teacher(string name, string birthday, GenderType gender) : base(name, birthday, gender)
        {
            this.Classes = new HashSet<ClassBook>();
        }

        internal void AssignClass(ClassBook classBook)
        {
            this.Classes.Add(classBook);
        }
    }
}
