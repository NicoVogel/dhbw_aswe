using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public GenderType Gender { get; set; }

        public Person()
        {
        }

        public Person(string name, DateTime birthday, GenderType gender)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.Birthday.Year;
            }
        }
    }
}
