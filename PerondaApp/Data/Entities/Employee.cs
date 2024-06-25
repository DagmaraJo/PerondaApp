namespace PerondaApp.Data.Entities
{
    public class Employee : EntityBase
    {
        //public Employee()
        //{
        //}

        //public Employee(string name)
        //{
        //}


        public string? FirstName { get; set; }

        public override string ToString() => $"Employee ID: {Id}, Firstname: {FirstName}";
    }
}
