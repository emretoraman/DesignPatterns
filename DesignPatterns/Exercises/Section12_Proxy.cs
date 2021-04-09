namespace DesignPatterns.Exercises.Section12_Proxy
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            _ = GetType();
            return "drinking";
        }

        public string Drive()
        {
            _ = GetType();
            return "driving";
        }

        public string DrinkAndDrive()
        {
            _ = GetType();
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private readonly Person person;
        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public string Drink()
        {
            return Age >= 18 ? person.Drink() : "too young";
        }

        public string Drive()
        {
            return Age >= 16 ? person.Drive() : "too young";
        }

        public string DrinkAndDrive()
        {
            _ = GetType();
            return "dead";
        }

        public int Age 
        {
            get => person.Age;
            set => person.Age = value;
        }
    }
}
