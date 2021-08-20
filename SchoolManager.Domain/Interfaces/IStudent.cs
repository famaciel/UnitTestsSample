using System;

namespace SchoolManager.Domain.Interfaces
{
    public interface IStudent
    {
         Guid Id { get; }
        string Name { get; }
        string Document { get; }
        DateTime BirthDate { get; }
        double Points { get; }

        void SetPoints(double points);
        void IncreasePoints(double points);
    }
}