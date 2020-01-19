using Newtonsoft.Json;
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

        [JsonConstructor]
        public Person(string name, string birthday, GenderType gender)
        {
            this.Name = name;
            this.Birthday = DateTime.Parse(birthday);
            this.Gender = gender;
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

        public override string ToString()
        {
            return Name;
        }
    }
}
