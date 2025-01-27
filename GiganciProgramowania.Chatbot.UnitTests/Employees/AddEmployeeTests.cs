using FluentAssertions;
using Moq;
using GiganciProgramowania.Chatbot.Application.Employees;
using GiganciProgramowania.Chatbot.Application.Employees.AddEmployee;
using GiganciProgramowania.Chatbot.Domain.Employees;

namespace GiganciProgramowania.Chatbot.UnitTests.Employees
{

    public  class AddEmployeeTests
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private Mock<IEmployeeIdentificationNumberService> _employeeIdentificationNumberServiceMock;
        private AddEmployeeCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeIdentificationNumberServiceMock = new Mock<IEmployeeIdentificationNumberService>();
            _handler = new AddEmployeeCommandHandler(_employeeRepositoryMock.Object, _employeeIdentificationNumberServiceMock.Object);
        }

        [Test]
        public async void AddEmployee_WhenAllParamsCorrect_ThenEmployeeAdded()
        {
            //Given
            var command = new SendMessageCommand("Testowe", "Male");
            var cancellationToken = CancellationToken.None;

            _employeeIdentificationNumberServiceMock.Setup(x => x.GenerateIdentificationNumberAsync(cancellationToken)).ReturnsAsync("00000011");

            //When
            var employee = await _handler.Handle(command, cancellationToken);

            //Then

            employee.Should().NotBeNull();
            _employeeIdentificationNumberServiceMock.Verify(x => x.GenerateIdentificationNumberAsync(cancellationToken), Times.Once());
            _employeeRepositoryMock.Verify(x => x.AddEmployeeAsync(employee, cancellationToken), Times.Once());


        }
    }
}
