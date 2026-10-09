using System; // be able to use classes from the System namespace

namespace HelloWorld // organize code, is a container for classes and sub-namespaces
{
  class Program 
  // class is a container for variables and functions
  // everything must be inside a class
  {
    static void Main(string[] args) // the Main method gets executed
    {
      Console.WriteLine("Hello World!");
      // console is a class of the System namespace
      // it's WriteLine method is used to print to the console
    }
  }
}

// every statement end with a semicolon ;