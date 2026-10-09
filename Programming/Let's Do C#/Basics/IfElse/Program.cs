int age = 12;

if (age > 2)
{
    System.Console.WriteLine("Yes");
}
else
{
    System.Console.WriteLine("No");
}

int number = 78;

if (number < 0)
{
    System.Console.WriteLine("Negative");
}
else if (number == 0)
{
    System.Console.WriteLine("ZERO");
}
else
{
    System.Console.WriteLine("Positive");
}

// SHORTHAND

double temp = -5.4D;
string weater = (temp < 10) ? "Cold" : "Hot";
System.Console.WriteLine(weater);