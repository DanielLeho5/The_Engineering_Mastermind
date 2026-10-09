// BASICS

// type variableName = value

string name = "Daniel";
Console.WriteLine(name);

int age;
age = 20;
age = 21;
Console.WriteLine(age);

int myNum = 5;
double myDecimal = 3.12;
char myLetter = 'G'; // single quotes
bool myBool = true;
string myText = "hello"; // double quotes

// CONSTANTS

const int myConstantNumber = 12;
// myConstantNumber = 15; // -> error

// DISPLAYING VARIABLES

Console.WriteLine("Hello " + name);

string first = "John";
string last = "Smith";
string full = first + " " + last;
Console.WriteLine("Hello " + full + "!");

int x = 5;
int y = 12;
System.Console.WriteLine(x + y);

// MULTIPLE VARIBALES

int a = 7, b = 6, c = 2;
System.Console.WriteLine(a + b + c);

int d, e, f;
d = e = f = 3;
System.Console.WriteLine(f);

// IDENTIFIERS

// The general rules for naming variables are:

// Names can contain letters, digits and the underscore character (_)
// Names must begin with a letter or underscore
// Names should start with a lowercase letter, and cannot contain whitespace
// Names are case-sensitive ("myVar" and "myvar" are different variables)
// Reserved words (like C# keywords, such as int or double) cannot be used as names

int myNumber = 2;