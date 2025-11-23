// In case you need some guidance: https://refactoring.guru/design-patterns/adapter
namespace DesignPattern.Adapter
{
    public class EmployeeAdapter : ITarget
    {
        private readonly BillingSystem thirdPartyBillingSystem = new();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            var employeeList = new List<Employee>();

            int rows = employeesArray.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                int id = int.Parse(employeesArray[i, 0]);
                string name = employeesArray[i, 1];
                string designation = employeesArray[i, 2];
                decimal salary = decimal.Parse(employeesArray[i, 3]);

                var employee = new Employee(id, name, designation, salary);
                employeeList.Add(employee);
            }

            thirdPartyBillingSystem.ProcessSalary(employeeList);
        }
    }
}
