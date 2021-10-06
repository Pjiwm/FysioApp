using Domain;
using Infrastructure;
using Moq;
using Portal.Models;
using System.Collections.Generic;
using Xunit;
namespace Tests
{
    public class CanAddPatientToRepository
    {
        [Fact]
        public void Can_Add_Patient_To_Patient_Repository()
        {
            var patientMock = new Mock<IPatientRepository>();
            patientMock.Setup(s => s.Patients).Returns(new List<Patient>());
            var patientViewModel = new AddPatientViewModel()
            {
                Name = "Joe Nuts",
                EMail = "Test@joe.nl",
                PatientID = 0,
                DateOfBirth = System.DateTime.Now,
                Gender = Gender.Male,
                PhoneNumber = "0612345678"
            };
            var sut = patientMock.Object;

            Patient domainPatient = ModelHelperMethods.ToDomain(patientViewModel);
            sut.Patients.Add(domainPatient);

            Assert.True(sut.Patients.Count != 0);

        }
    }
}
