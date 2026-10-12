class Animal
{
    public string name;
    public int age;
    public Animal(string name, int age) { // constructor
        this.name = name;
        this.age = age;
    }
    public void makeNoise()
    {
        System.Console.WriteLine($"Ahoooj! I am a {age} years old {name}.");
    }
}