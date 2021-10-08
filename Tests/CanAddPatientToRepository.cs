using Domain;
using Infrastructure;
using Moq;
using Portal.Models;
using System;
using System.Collections.Generic;
using Xunit;
namespace Tests
{
    public class CanAddPatientToRepository
    {
        [Fact]
        public void Age_Patient_Is_Sixteen_Or_More()
        {
            var patientViewModel = new AddPatientViewModel()
            {
                Name = "Joe Nuts",
                EMail = "Test@joe.nl",
                PatientID = 0,
                DateOfBirth = System.DateTime.Now.AddYears(-40),
                Gender = Gender.Male,
                PhoneNumber = "0612345678",
                Role = PatientRole.Student
            };



            Patient domainPatient = ModelHelperMethods.ToDomain(patientViewModel);
            var patientMock = new Mock<IPatientRepository>();
            patientMock.Setup(s => s.ReadByID(0)).Returns(domainPatient);
            patientMock.Setup(s => s.Count()).Returns(1);
            var sut = patientMock.Object;
            //sut.Add(domainPatient);

            Assert.True(DateTime.Now.Year -  sut.ReadByID(0).DateOfBirth.Year >= 16);

        }
    }
}
