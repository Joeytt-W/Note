
using Newtonsoft.Json;

namespace PropertypePattern
{
    /// <summary>
    /// Property
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public abstract Person Clone(bool deepClone);
    }

    /// <summary>
    /// ConcretePropertype1
    /// </summary>
    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }
            //浅拷贝
            return (Person)MemberwiseClone();
        }
    }

    /// <summary>
    /// ConcretePropertype2
    /// </summary>
    public class Employee : Person
    {
        public Manager Manager { get; set; }
        public override string Name { get ; set ; }

        public Employee(string name,Manager manager)
        {
            Manager = manager;
            Name = name;
        }

        public override Person Clone(bool deepClone = false)
        {
            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Employee>(objectAsJson);
            }

            return (Person)MemberwiseClone();
        }
    }
}
