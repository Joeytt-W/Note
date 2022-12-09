using GrpcServer.Web.Protos;

namespace GrpcServer.Web.Data
{
    public class InMemoryData
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                No = 1994,
                FirstName = "Chandler",
                LastName = "Bing",
                Salary = 2000
            },
            new Employee()
            {
                Id = 2,
                No = 1999,
                FirstName = "Rachael",
                LastName = "Green",
                Salary = 2400
            },
            new Employee()
            {
                Id = 3,
                No = 2002,
                FirstName = "Json",
                LastName = "White",
                Salary = 1800
            },
        };
    }
}
