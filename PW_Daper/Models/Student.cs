using System;

namespace PW_Daper.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName + " " + LastName}, BirthDate: {BirthDate.ToShortDateString()}";
        }
    }
}
