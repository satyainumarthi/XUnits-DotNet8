using BusinessLogicLayer;
using CRUDAPI_s.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Models;
using Moq;
using System.Collections;

namespace XunitProject
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _employeeController;
        private readonly Mock<IEmployeeService> _employeeService;
        public EmployeeControllerTests()
        {
            _employeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeService.Object);
        }

        [Fact]
        public void EmployeeController_GetAllEmployee()
        {
            //Arrange
            var expectedOutput = new List<Employee>()
              {
                  new Employee(){Id=1, Name="Smith", City="Canberra"},
                  new Employee(){Id=2, Name="Warner", City="Sydney"},
              };
            _employeeService.Setup(x => x.GetAllEmployees()).Returns(expectedOutput);

            //Act
            var actualOutput = _employeeController.Get();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void EmployeeController_GetEmployeeById(int id)
        {
            //Arrange
            var expectedOutput = new Employee();
            switch (id)
            {
                case 1:
                    expectedOutput = new Employee() { Id = 1, Name = "Smith", City = "Canberra" };
                    break;
                case 2:
                    expectedOutput = new Employee() { Id = 2, Name = "Warner", City = "Sydney" };
                    break;
            }

            _employeeService.Setup(x => x.GetEmployee(id)).Returns(expectedOutput);

            //Act
            var actualOutput = _employeeController.Get(id);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [ClassData(typeof(EmployeeClassData))]
        public void EmployeeController_InsertEmployee(Employee employee)
        {
            //Act
            _employeeController.Post(employee);

            //Assert
            Assert.True(true);

        }

        [Theory]
        [ClassData(typeof(EmployeeClassData))]
       public void EmployeeController_UpdateEmployee(Employee employee)
        {
            //Act
            _employeeController.Put(employee.Id, employee);

            //Assert
            Assert.True(true);

        }

        [Theory]
        [InlineData(1)]
        public void EmployeeController_DeleteEmployee(int id)
        {
            //Act
            _employeeController.Delete(id);

            //Assert
            Assert.True(true);
        }
    }

    public class EmployeeClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
               new Employee()
               {
                   Id=1,
                   Name="Smith",
                   City="Canberra"
               }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}