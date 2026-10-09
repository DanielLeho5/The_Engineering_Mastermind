// BASICS

string text = "Hello, this is a sentence!";
System.Console.WriteLine(text);
System.Console.WriteLine("The length is: " + text.Length);
System.Console.WriteLine(text.ToUpper());
System.Console.WriteLine(text.ToLower());

// CONCATENATION
string first = "John";
string last = "Doe";
//string full = first + " " + last;
string full = string.Concat(first, " ", last);
System.Console.WriteLine(full);

// INTERPOLATION
System.Console.WriteLine($"My name is: {first} {last}!");

// INDEXING STRINGS
System.Console.WriteLine($"The first letter is: {first[0]}");
System.Console.WriteLine($"The first index of \"h\" is at position {first.IndexOf('h')}"); // can be used to find string aswell

System.Console.WriteLine(full.Substring(2,5));

// SPECIAL CHARACTERS
string myString = "\" \' \\ \n \t \b";