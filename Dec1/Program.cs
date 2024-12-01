// PART ONE

// Get path to the puzzle input
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

var root_dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent;

if (root_dir == null)
{
    throw new Exception("Could not locate root directory.");
}
var puzzle_path = Path.Combine(root_dir.ToString(), "data", "puzzle_input.txt");

// Read file into string
string puzzle_input = String.Empty;
try 
{ 
    using StreamReader reader = new(puzzle_path);

    puzzle_input = reader.ReadToEnd();
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}

// Parse into arrays
var lines = puzzle_input.Split('\n');
int[] list_one = new int[lines.Length];
int[] list_two = new int[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    
    if (values.Length != 2)
    {
        throw new Exception($"Error parsing line number {i}");
    }

    list_one[i] = int.Parse(values[0]);
    list_two[i] = int.Parse(values[1]);
}

// Sort arrays from smallest to largest
Array.Sort(list_one);
Array.Sort(list_two);

// Calculate distance
var distance = 0;

for (int i = 0; i < list_one.Length; i++)
{
    var diff = list_one[i] - list_two[i];
    distance += int.Abs(diff);
}

// Report
Console.WriteLine($"The distance is {distance}");

// PART TWO

// Calculate similarity
int similarity = 0;
for (int i = 0; i < list_one.Length; i++)
{
    var current = list_one[i];
    var occurences = Array.FindAll(list_two, x => x == current).Length;
    similarity += current * occurences;
}

// Report
Console.WriteLine($"The similarity is {similarity}");