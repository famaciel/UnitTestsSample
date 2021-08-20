using System;
using SchoolManager.Domain;
using SchoolManager.Domain.Interfaces;
using Xunit;

namespace SchoolManager.Tests
{
    public class StudentTest
    {
        [Fact]
        public void StudentMustHaveZeroPointsInCreation()
        {
            IStudent student = new Student("David", "12345678911", new DateTime(2000, 05, 10));

            Assert.Equal(0, student.Points);
        }

        [Fact]
        public void CannotSetPointsMoreThan100()
        {
            IStudent student = new Student("David", "12345678911", new DateTime(2000, 05, 10));

            Assert.Throws<Exception>(() => student.SetPoints(101));
        }

        [Fact]
        public void CannotSetPointsLessThan0()
        {
            IStudent student = new Student("David", "12345678911", new DateTime(2000, 05, 10));

            Assert.Throws<Exception>(() => student.SetPoints(-1));
        }

        [Fact]
        public void CannotIncreaseNegativePoints()
        {
            IStudent student = new Student("David", "12345678911", new DateTime(2000, 05, 10));

            var exc = Assert.Throws<Exception>(() => student.IncreasePoints(-10));
            Assert.Equal("The value cannot be negative", exc.Message);
        }

        [Fact]
        public void InIncreasePointsTheFinalPointsCannotExceed100()
        {
            IStudent student = new Student("David", "12345678911", new DateTime(2000, 05, 10));

            student.SetPoints(50);

            var exc = Assert.Throws<Exception>(() => student.IncreasePoints(60));
            Assert.Equal("The final points cannot exceed 100", exc.Message);
        }

        [Fact]
        public void IncreasePoints()
        {
            IStudent student = new Student("David", "12345678911", new DateTime(2000, 05, 10));

            student.SetPoints(50);
            student.IncreasePoints(34.9);
            
            Assert.Equal(84.9, student.Points);
        }
    }
}