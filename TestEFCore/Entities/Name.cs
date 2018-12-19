using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestEFCore.Entities
{
    
    public class Name
    {
        [Required] // not null
        public string FirstName { get; set; }

        [Required] // not null
        public string LastName { get; set; }

        public Name(string FirstName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Имя и фамилия должны быть определены!");

            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override bool Equals(object obj)
        {
            Name name = obj as Name;

            if (name == null)
                throw new ArgumentException("Аргумент не является типом Name");

            return (FirstName.Equals(name.FirstName) && LastName.Equals(name.LastName));
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
