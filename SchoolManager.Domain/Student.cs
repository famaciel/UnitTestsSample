using System;
using SchoolManager.Domain.Interfaces;

namespace SchoolManager.Domain
{
    public class Student : IStudent
    {
        public Student(string name, string document, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Document = document;
            BirthDate = birthDate;
            Points = 0;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public double Points { get; private set; }

        public void IncreasePoints(double points)
        {
            if (points < 0)
                throw new Exception("The value cannot be negative");

            if (Points + points > 100)
                throw new Exception("The final points cannot exceed 100");
            
            Points += points;
        }

        public void SetPoints(double points)
        {
            if (points > 100)
                throw new Exception("Points cannot exceed 100");

            if (points < 0)
                throw new Exception("Points cannot be less than 0");

            Points = points;
        }


    }
}