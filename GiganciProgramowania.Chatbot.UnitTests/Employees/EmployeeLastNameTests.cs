using FluentAssertions;
using GiganciProgramowania.BuildingBlocks.Domain;
using GiganciProgramowania.Chatbot.Domain.Employees;

namespace GiganciProgramowania.Chatbot.UnitTests.Employees
{
    public class EmployeeLastNameTests
    {
        [Test]
        public void Create_WhenMissingLastName_ShouldThrowBusinessException()
        {
            // Given
            string? lastName = null;

            // When
            Action act = () => new EmployeeBuilder()
                .WithLastName(lastName)
                .Create();

            // Then
            act.Should().Throw<BusinessException>()
                .WithMessage("Last name cannot be empty.")
                .Where(e => e is BusinessException && ((BusinessException)e).ErrorCode == "LastName.Empty");
        }

        [Test]
        public void Create_WhenLastNameExceedsMaxLength_ShouldThrowBusinessException()
        {
            // Given
            string lastName = "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest";

            // When
            Action act = () => new EmployeeBuilder()
                .WithLastName(lastName)
                .Create();

            // Then
            act.Should().Throw<BusinessException>()
                .WithMessage("Last name must be between 1 and 50 characters.")
                .Where(e => e is BusinessException && ((BusinessException)e).ErrorCode == "LastName.InvalidLength");
        }

        [Test]
        public void Create_WhenValidInput_ShouldCreateEmployeeSuccessfully()
        {
            // Given
            string lastName = "Smith";
            string identificationNumber = EmployeeIdentificationNumberGenerator.GenerateEmployeeId(101);
            EmployeeSex employeeSex = EmployeeSex.Male;

            // When
            var employee = new EmployeeBuilder()
                .WithLastName(lastName)
                .WithIdentificationNumber(identificationNumber)
                .WithSex(employeeSex)
                .Create();

            // Then
            employee.Should().NotBeNull();
            employee.LastName.Value.Should().Be(lastName);
            employee.IdentificationNumber.Value.Should().Be(identificationNumber);
            employee.Sex.Should().Be(employeeSex);
        }
    }
}
