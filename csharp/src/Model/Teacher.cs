using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvvm.Model
{
    public class Teacher : Person
    {
        public List<StudentCollection> Classes { get; set; }

        [JsonConstructor]
        public Teacher(string name, string birthday, GenderType gender) : base(name, birthday, gender)
        {
            this.Classes = new List<StudentCollection>();
        }
    }
}
