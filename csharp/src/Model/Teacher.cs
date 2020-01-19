using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Teacher : Person
    {
        public ISet<ClassBook> ClassBooks { get; private set; }

        public Teacher(string name, DateTime birthday, GenderType gender, ISet<ClassBook> classBooks) : base(name, birthday, gender)
        {
            this.ClassBooks = classBooks;
        }

        [JsonConstructor]
        public Teacher(string name, string birthday, GenderType gender) : base(name, birthday, gender)
        {
            this.ClassBooks = new HashSet<ClassBook>();
        }
    }
}
