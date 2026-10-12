
class Car
{
    // class members are the attributes + methods
    // deafult values can be assgined like so >>
    public string color = "red"; // attribute
    // public -> accesible from other classes
    public int maxSpeed = 120;

    public void startEngine()
    {
        System.Console.WriteLine("Brrrrr!");
    }
}

class Pogram
{
    static void Main(string[] args)
    {
        Car car1 = new Car();
        System.Console.WriteLine(car1.color);
        System.Console.WriteLine(car1.maxSpeed);
        car1.startEngine();

        Car car2 = new Car();
        car2.color = "green";
        car2.maxSpeed = 200;
        System.Console.WriteLine(car2.color);
        System.Console.WriteLine(car2.maxSpeed);

        // using class from another file
        Animal a = new Animal(name: "animal", 12);
        a.name = "dog";
        a.makeNoise();
    }
}