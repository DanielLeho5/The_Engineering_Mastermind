print(3 > 2)
print(1 > 3)

a = 200
b = 7

if (a > b):
    print('hellooooo')
else:
    print('nooooooo')

print(bool("hello"))
print(bool(1))
print(bool([1, 2, 3]))

print(bool(False))
print(bool(None))
print(bool(0))
print(bool(""))
print(bool(()))
print(bool([]))
print(bool({}))

class myclass():
  def __len__(self):
    return 0

myobj = myclass()
print(bool(myobj))

print(isinstance(10, int))