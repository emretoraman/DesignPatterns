namespace DesignPatterns.Exercises.Section03_Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class PersonFactory
    {
        private int nextId = 0;

        public Person CreatePerson(string name)
        {
            return new Person(nextId++, name);
        }
    }
}
