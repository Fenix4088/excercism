using Exercism.BethanyShop.Enteties;

namespace BethaniShopTest;

public class EmployeeTests
{
    [Fact]
    public void PerformWork_Adds_NumberOfHours()
    {
        //Arrange
        Employee employee = new ("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);

        int numberOfHours = 3;
        
        //Act
        employee.PerformWork(numberOfHours);
        
        //Assert
        Assert.Equal(numberOfHours, employee.NumberOfHoursWorked);
    }

    [Fact]
    public void PerformWork_Adds_DefaultNumberOfHours_IfNoValueSpecified()
    {
        //Arrange
        Employee employee = new ("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);

        
        //Act
        employee.PerformWork();
        
        //Assert
        Assert.Equal(1, employee.NumberOfHoursWorked);
    }
}