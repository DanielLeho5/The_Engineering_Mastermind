int myNum = 5;               // Integer (whole number)
long myLong = 1100000000L;
float myFloat = 12.99F;
double myDoubleNum = 5.99D;  // Floating point number
char myLetter = 'D';         // Character
bool myBool = true;          // Boolean
string myText = "Hello";     // String

// int	    4 bytes	    Stores whole numbers from -2,147,483,648 to 2,147,483,647
// long	    8 bytes	    Stores whole numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
// float	4 bytes	    Stores fractional numbers. Sufficient for storing 6 to 7 decimal digits
// double	8 bytes	    Stores fractional numbers. Sufficient for storing 15 decimal digits
// bool	    1 byte	    Stores true or false values
// char	    2 bytes	    Stores a single character/letter, surrounded by single quotes
// string	2 bytes per character

float f1 = 35e3F; // 35 * 10^3
double d1 = 12E4D; // 12 * 10^4

bool isCSharpFun = true;
bool isFishTasty = false;
Console.WriteLine(isCSharpFun);   // Outputs True
Console.WriteLine(isFishTasty);   // Outputs False

char myGrade = 'B';
Console.WriteLine(myGrade);

string greeting = "Hello World";
Console.WriteLine(greeting);

// TYPE CASTING

int myInt = 12;
int myDouble = myInt; // implicit casting (it's implied, trivial)

System.Console.WriteLine(myInt);
System.Console.WriteLine(myDouble);

double myDouble2 = 13.54;
int myInt2 = (int) myDouble2; // rounded
System.Console.WriteLine(myInt2);

System.Console.WriteLine(Convert.ToString(myInt));
System.Console.WriteLine(Convert.ToString(myDouble));
System.Console.WriteLine(Convert.ToString(myBool));
System.Console.WriteLine(Convert.ToDouble(myInt));
System.Console.WriteLine(Convert.ToInt32(myBool));