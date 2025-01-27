using FluentAssertions;
using GiganciProgramowania.Chatbot.Domain.Employees;

namespace GiganciProgramowania.Chatbot.UnitTests.Employees;

public class EmployeeIdentificationNumberGeneratorTests
{
    [Test]
    public void GenerateEmployeeIdentNumber_WhenCalled_ShouldIncrementAndReturnWithLeadingZeros()
    {
        // Given
        int initialNumber = 1;

        // When
        var result = EmployeeIdentificationNumberGenerator.GenerateEmployeeId(initialNumber);

        // Then
        result.Should().Be("00000002");
    }

    [Test]
    public void GenerateEmployeeIdentNumber_WhenNumberHasLeadingZeros_ShouldPreserveLeadingZeros()
    {
        // Given
        int initialNumber = 0000007;

        // When
        var result = EmployeeIdentificationNumberGenerator.GenerateEmployeeId(initialNumber);

        // Then
        result.Should().Be("00000008");
    }

    [Test]
    public void GenerateEmployeeIdentNumber_WhenNumberIsNegative_ShouldThrowArgumentException()
    {
        // Given
        int initialNumber = -1;

        // When
        Action act = () => EmployeeIdentificationNumberGenerator.GenerateEmployeeId(initialNumber);

        // Then
        act.Should().Throw<ArgumentException>()
            .WithMessage("Current number of employees cannot be negative.");
    }

    [Test]
    public void GenerateEmployeeIdentNumber_WhenNumberIsZero_ShouldGenerateIdWithLeadingZeros()
    {
        // Given
        int initialNumber = 0;

        // When
        var result = EmployeeIdentificationNumberGenerator.GenerateEmployeeId(initialNumber);

        // Then
        result.Should().Be("00000001");
    }
}
