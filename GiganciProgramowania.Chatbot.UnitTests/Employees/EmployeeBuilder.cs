using GiganciProgramowania.Chatbot.Domain.Employees;
using GiganciProgramowania.Chatbot.Domain.Employees.Properties;

namespace GiganciProgramowania.Chatbot.UnitTests.Employees
{
    public class EmployeeBuilder
    {
        private LastName _lastName = new LastName("Kowalski");
        private IdentificationNumber _identificator = new IdentificationNumber("00000001");
        private EmployeeSex _employeeSex = EmployeeSex.Male;

        public EmployeeBuilder WithLastName(string lastName)
        {
            _lastName = new LastName(lastName);
            return this;
        }

        public EmployeeBuilder WithIdentificationNumber(string identificator)
        {
            _identificator = new IdentificationNumber(identificator);
            return this;
        }

        public EmployeeBuilder WithSex(EmployeeSex sex)
        {
            _employeeSex = sex;
            return this;
        }

        public Message Create()
        {
            return Message.Create(_lastName, _identificator, _employeeSex);
        }
    }
}
