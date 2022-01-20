namespace Client
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(){}
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} is {Age} years old";
        }
    }
}