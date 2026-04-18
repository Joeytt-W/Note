namespace Memento
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


    public class Manager : Employee
    {
        public List<Employee> Employees = new();
        public Manager(int id, string name) : base(id, name)
        {

        }
    }


    /// <summary>
    /// Receiver(interface)
    /// </summary>
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);

        void RemoveEmployee(int managerId, Employee employee);

        bool HasEmployee(int managerId, int employeeId);

        void WriteDataStore();
    }

    /// <summary>
    /// Receiver(implementation)
    /// </summary>
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>() { new Manager(1, "Katie"), new Manager(2, "Geoff") };
        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employeeId);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id},{manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id},{employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"No employee.");
                }
            }
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    public interface ICommand
    {
        void Execute();

        bool CanExecute();

        void Undo();
    }

    /// <summary>
    /// ConcreteCommand
    /// </summary>
    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private int _managerId;
        private Employee? _employee;

        public AddEmployeeToManagerList(
            IEmployeeManagerRepository employeeManagerRepository,
            int managerId,
            Employee? employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public void Execute()
        {
            if (_employee == null)
            {
                return;
            }
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public void Undo()
        {
            if (_employee == null)
                return;

            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }

        public bool CanExecute()
        {
            if (_employee == null)
            {
                return false;
            }

            if (_employeeManagerRepository.HasEmployee(_managerId, _employee.Id))
            {
                return false;
            }


            return true;
        }


        public AddEmployeeToManagerListMemento CreateMemento()
        {
            return new AddEmployeeToManagerListMemento(_managerId, _employee);
        }


        public void RestoreMemento(AddEmployeeToManagerListMemento memento)
        {
            _managerId = memento.ManagerId;
            _employee = memento.Employee;
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    public class CommandManager
    {
        private readonly Stack<AddEmployeeToManagerListMemento> _mementos = new Stack<AddEmployeeToManagerListMemento>();

        private AddEmployeeToManagerList? _command;

        public void Invoke(ICommand command)
        {
            if(_command == null)
            {
                _command = (AddEmployeeToManagerList)command;
            }

            if (command.CanExecute())
            {
                command.Execute();
                _mementos.Push(((AddEmployeeToManagerList)command).CreateMemento());
            }
        }

        public void Undo()
        {
            if (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }

        public void UndoAll()
        {
            while (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }
    }


    public class AddEmployeeToManagerListMemento
    {
        public AddEmployeeToManagerListMemento(int managerId,Employee? employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }

        public int ManagerId { get; private set; }
        public Employee? Employee { get; private set; }
    }
}
