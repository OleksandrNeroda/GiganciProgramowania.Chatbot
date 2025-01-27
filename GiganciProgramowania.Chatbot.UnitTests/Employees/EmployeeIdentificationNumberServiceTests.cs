using FluentAssertions;
using Moq;
using GiganciProgramowania.Chatbot.Application.Employees;
using GiganciProgramowania.Chatbot.Domain.Employees;

namespace GiganciProgramowania.Chatbot.UnitTests.Employees
{
    public class EmployeeIdentificationNumberServiceTests
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private IEmployeeIdentificationNumberService _identificationNumberService;

        [SetUp]
        public void SetUp()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _identificationNumberService = new EmployeeIdentificationNumberService(_employeeRepositoryMock.Object);
        }

        [Test]
        public async Task GenerateIdentificationNumberAsync_WhenThereAreNoEmployees_ShouldGenerateId001()
        {
            // Given
            _employeeRepositoryMock.Setup(repo => repo.GetEmployeeCountAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            // When
            var result = await _identificationNumberService.GenerateIdentificationNumberAsync(CancellationToken.None);

            // Then
            result.Should().Be("00000001");
        }
    }
}
