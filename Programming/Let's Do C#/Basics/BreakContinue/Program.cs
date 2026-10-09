for (int i = 0; i < 10; i++)
{
    if (i == 6)
    {
        break; // stop before 6
    }
    else if (i == 4)
    {
        continue; // skip 4
    }
    
    System.Console.WriteLine(i);
}

System.Console.WriteLine("##############");

int j = 0;
while (j < 10)
{
    if (j == 4)
    {
        j++;
        continue; // skip 4
    }
    else if (j == 6)
    {
        break; // stop before 6
    }

    System.Console.WriteLine(j);
    j++;
}