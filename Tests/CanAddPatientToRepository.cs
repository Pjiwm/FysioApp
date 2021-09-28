using Domain;
using Infrastructure;
using Moq;
using Portal.Models;
using System.Collections.Generic;
using Xunit;
namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Can_Add_Patient_To_Patient_Repository()
        {
            var patientMock = new Mock<IPatientRepository>();
            patientMock.Setup(s => s.Patients).Returns(new List<Patient>());
            var patientViewModel = new AddPatientViewModel()
            {
                TreatmentPlan = "Medicine",
                Age = new System.DateTime(1999, 10, 20),
                Description = "Test patient",
                RegistrationDate = System.DateTime.Now,
                Name = "Joe Nuts"
            };
            var sut = patientMock.Object;

            Patient domainPatient = ModelHelperMethods.ToDomain(patientViewModel);
            sut.Patients.Add(domainPatient);

            Assert.True(sut.Patients.Count != 0);

        }
    }
}
