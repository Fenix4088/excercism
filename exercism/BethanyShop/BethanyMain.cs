using Exercism.BethanyShop.Enteties;

namespace Exercism.BethanyShop;

public class BethanyMain
{
    public void Init()
    {

        Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25, EmployeeType.Manager);
        Employee george = new("George", "Jones", "george@snowball.be", new DateTime(1984, 3, 28), 30, EmployeeType.Research);
        Employee mary = new Employee("Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30, EmployeeType.Manager);
        Employee bobJunior = new Employee("Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17, EmployeeType.Research);
        Employee kevin = new Employee("Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10);
        Employee kate = new Employee("Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10);
        Employee kim = new Employee("Kim", "Jacobs", "kim@snowball.be", new DateTime(1975, 5, 14), 22);
        
        Employee[] employees = new Employee[7]
        {
            bethany,
            george,
            mary,
            bobJunior,
            kevin,
            kate,
            kim
        };
        
        foreach (var employee in employees)
        {
            int workingHours = new Random().Next(1, 100);
            employee.PerformWork(workingHours);
            employee.ReceiveWage();
        }
    }
    
}
