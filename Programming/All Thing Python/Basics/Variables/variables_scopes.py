x = "global variable"

def func1():
    print("This varibale can still be seen: x: " + x)

def func2():
    x = "local variable"
    print("This varibale can still be seen: x:", x)

func1()
func2()
print("This variaable is unchanged:", x)

def func3():
    global x # use it if you want to change the value of a global variable
    x = "changed global variable"

func3()
print("This varibale has now changed:", x)