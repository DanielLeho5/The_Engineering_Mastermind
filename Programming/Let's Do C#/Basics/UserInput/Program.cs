System.Console.Write("Enter username: ");
string username = Console.ReadLine();

System.Console.Write("Enter your age: ");
int age = Convert.ToInt32(Console.ReadLine());

System.Console.WriteLine("Hello, " + username + "!");
System.Console.WriteLine("Next year you'll be " + (age + 1) + " years old.");