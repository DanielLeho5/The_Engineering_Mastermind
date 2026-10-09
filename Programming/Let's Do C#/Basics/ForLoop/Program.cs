// FOR LOOP

for (int i = 0; i < 5; i++)
{
    System.Console.WriteLine($"The loop variable is: {i}");
}

// nested loops
for (int i = 0; i <= 3; i++)
{
    for (int j = 0; j <= 3; j++)
    {
        System.Console.Write($"({i}-{j})");
    }
    System.Console.WriteLine();
}

// FOREACH

string[] cars = ["volvo", "ferrari", "mazda", "honda"];

foreach (string car in cars)
{
    System.Console.WriteLine($"Today I'm driving a {car}.");
}