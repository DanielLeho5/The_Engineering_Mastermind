class Program
{
    static void MyMethod() // static -> method belongs to the Program class, not an instance of it
    {
        System.Console.WriteLine("Hello!");
    }

    // method with parameters
    static void MyMethod2(string name, int age, string country = "USA") // default parameter
    {
        System.Console.WriteLine($"Your name is {name}, you are {age} years old and you are from {country}!");
    }

    static int Sum(int number1, int number2) // return type int
    {
        return number1 + number2;
    }

    // named arguments
    static string FullName(string first, string last)
    {
        return first + " " + last;
    }

    // METHOD OVERLOADING
    // methods can have the same name, but can be differentiated by the parameters
    // not differentiated by the return type !!!
    static void Subtract(int num1, int num2)
    {
        System.Console.WriteLine(num1 - num2);
    }
    static void Subtract(double num1, double num2)
    {
        System.Console.WriteLine(num1 - num2);
    }

    static void Main(string[] args) // runs when file is excuted
    {   
        MyMethod();
        MyMethod2("Daniel", 12);

        int sum = Sum(1, 5);
        System.Console.WriteLine(sum);

        System.Console.WriteLine(FullName(last: "Lehoczki", first: "Daniel")); // named args
    }
}
