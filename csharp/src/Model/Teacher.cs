using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Teacher : Person
    {
        public IList<ClassBook> ClassBooks { get; private set; } = new List<ClassBook>();

        public Teacher(string name, DateTime birthday, GenderType gender, IList<ClassBook> classBooks) : base(name, birthday, gender)
        {
            this.ClassBooks = classBooks;
        }

        [JsonConstructor]
        public Teacher(string name, string birthday, GenderType gender) : base(name, birthday, gender)
        {
            this.ClassBooks = new List<ClassBook>();
        }

        public Teacher()
        {
            this.ClassBooks = new List<ClassBook>();
        }
    }
}
