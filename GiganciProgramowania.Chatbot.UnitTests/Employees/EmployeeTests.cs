using FluentAssertions;
using GiganciProgramowania.Chatbot.Domain.Employees;

namespace GiganciProgramowania.Chatbot.UnitTests.Employees;

public class EmployeeTests
{

    [Test]
    public void Create_WhenAllArgsAreValid_ShouldCreateEmployee()
    {
        //Given
        string lastName = "Kowalski";
        string identificationNumber = EmployeeIdentificationNumberGenerator.GenerateEmployeeId(101);
        EmployeeSex employeeSex = EmployeeSex.Male;

        //When
        var employee = new EmployeeBuilder()
        .WithLastName(lastName)
        .WithIdentificationNumber(identificationNumber)
        .WithSex(employeeSex)
        .Create();
     
        //Then
        employee.Should().NotBeNull();
        employee.LastName.Value.Should().Be(lastName);
        employee.IdentificationNumber.Value.Should().Be(identificationNumber);
        employee.Sex.Should().Be(employeeSex);
    }
}