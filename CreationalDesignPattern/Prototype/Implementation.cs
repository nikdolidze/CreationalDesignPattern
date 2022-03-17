using Newtonsoft.Json;

namespace Prototype
{/*
  * prototype patterns itent is to specify the kinds of objects to create using a prototypical instance and craete new object by copying this prototype.
in other words it lets up copy existing objects without making the client code dependent on their concreate classes....
the prototype pattern obviously contains a Prototype class,that prototype declares an interface for cloning itself.
  * */
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract Person Clone(bool deepClone= false);
    }
    public class Manager : Person
    {
        public Manager(string name)
        {
            this.Name = name;
        }
        public override string Name { get ; set ; }

        public override Person Clone(bool deepClone= false)
        {

            if (deepClone)
            {
                var objectAsJson = JsonConvert.SerializeObject(this);
                return JsonConvert.DeserializeObject<Manager>(objectAsJson);
            }
            return (Person)MemberwiseClone();
        }
    }
    public class Employee: Person
    {
        public Employee(string name,Manager manager)
        {
            Manager = manager;
            this.Name = name;
        }
        public  override string Name { get; set; }
        public  Manager Manager { get; set; }
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