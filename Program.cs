using System;
using System.IO;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string file = Path.Combine(currentDirectory, @"..\..\..\input.txt");
string path = Path.GetFullPath(file);
string[] text = File.ReadAllText(path).Split("\n");

int maxCalories = 0;
int currentCalories = 0;
for (int i = 0; i < text.Length; i++)
{
    if (Int32.TryParse(text[i], out _))
    {
        currentCalories += Convert.ToInt32(text[i]);
    }
    else
    {
        if (currentCalories > maxCalories)
            maxCalories = currentCalories;
        currentCalories = 0;
    }
}

Console.WriteLine($"Max is {maxCalories}");

int[] maxArrayCalories = new int[3];
currentCalories = 0;
for (int i = 0; i < text.Length; i++)
{
    if (Int32.TryParse(text[i], out _))
    {
        currentCalories += Convert.ToInt32(text[i]);
    }
    else
    {
        if (currentCalories > maxArrayCalories[0])
        {
            maxArrayCalories[2] = maxArrayCalories[1];
            maxArrayCalories[1] = maxArrayCalories[0];
            maxArrayCalories[0] = currentCalories;
        }
        else if (currentCalories > maxArrayCalories[1])
        {
            maxArrayCalories[2] = maxArrayCalories[1];
            maxArrayCalories[1] = currentCalories;
        }
        else if (currentCalories > maxArrayCalories[2])
        {
            maxArrayCalories[2] = currentCalories;
        }
        currentCalories = 0;
    }
}

int sum = maxArrayCalories[2] + maxArrayCalories[1] + maxArrayCalories[0];
Console.WriteLine(sum);
