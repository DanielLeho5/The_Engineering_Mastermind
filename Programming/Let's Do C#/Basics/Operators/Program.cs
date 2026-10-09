// ARITHMETIC OPERATORS

// int x = 100 + 100;

int sum1 = 100 + 50;        // 150 (100 + 50)
int sum2 = sum1 + 250;      // 400 (150 + 250)
int sum3 = sum2 + sum2;     // 800 (400 + 400)

int x = 3, y = 4, z = 12;

double value;
value = x + y;
value = x - y;
value = x * y;
value = x / y;
value = x % y;
value++;
value--;

// ASSIGNMENT OPERATORS

double num = 12D;

num += 2;
num -= 8;
num *= 2;
num /= 10;
num %= 3;

int num2 = 2;
num2 ^= 2; // works on ints

bool myBool = true;
myBool &= false;
myBool |= false;


int a;
// bitwise shifts

a = 8;
// ...01000 -> ...00001
a >>= 3;
System.Console.WriteLine(a);

a = 5;
// ...00101 -> ...00101000 (= 8 + 32)
a <<= 3;
System.Console.WriteLine(a);

// COMPARISON OPERATOR

System.Console.WriteLine(3 == 2);
System.Console.WriteLine(3 != 2);
System.Console.WriteLine(3 > 2);
System.Console.WriteLine(3 < 2);
System.Console.WriteLine(3 >= 2);
System.Console.WriteLine(3 <= 2);

// LOGICAL OPERATORS

System.Console.WriteLine(false && true);
System.Console.WriteLine(false || true);
System.Console.WriteLine(!false);