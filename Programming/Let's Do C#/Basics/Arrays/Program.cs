// ARRAYS

string[] cars;
cars = ["volvo", "mazda", "ferrari", "mercedes"];

int[] myNums = {1, 2, 3, 4, 5};

System.Console.WriteLine($"I am driving a {cars[0]}.");

cars[0] = "fiat";
System.Console.WriteLine($"Now, I am driving a {cars[0]}.");

System.Console.WriteLine($"Length of cars is: {cars.Length}");

string[] cars2 = new string[4];
string[] cars3 = new string[4] {"volvo", "mazda", "fiat", "mercedes"};
string[] cars4 = new string[] {"volvo", "ferrari"};
string[] cars5 = {"volvo", "mazda"};

// loop through arrays

for (int i = 0; i < cars.Length; i++)
{
    System.Console.WriteLine(cars[i]);
}

foreach (string car in cars)
{
    System.Console.WriteLine(car);
}

System.Console.WriteLine("#################");

// sorting arrays
Array.Sort(cars); // alphanumerical order
System.Console.WriteLine(cars[0] + " " + cars[1] + " " + cars[2] + " " + cars[3]);

Array.Sort(myNums);

// other useful methods
System.Console.WriteLine(myNums.Max());
System.Console.WriteLine(myNums.Min());
System.Console.WriteLine(myNums.Sum());

// multidimensional arrays
int[,] array2D = {{1,2,3},{4,5,6}};
System.Console.WriteLine(array2D[0, 0]); // indexing !!!

array2D[0, 0] = 12;
System.Console.WriteLine(array2D[0, 0]);

System.Console.WriteLine("#############");

for (int i = 0; i < array2D.GetLength(0); i++)
{
    for (int j = 0; j < array2D.GetLength(1); j++)
    {
        System.Console.Write(array2D[i,j]);
    }
    System.Console.WriteLine();
}