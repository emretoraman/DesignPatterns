namespace DesignPatterns.Exercises.Section09_Decorator
{

    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private readonly Bird bird = new Bird();
        private readonly Lizard lizard = new Lizard();
        private int age;

        public int Age
        {
            get => age;
            set
            {
                age = value;
                bird.Age = value;
                lizard.Age = value;
            }
        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }
}
