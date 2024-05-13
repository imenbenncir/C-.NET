                // 1.Iterate and print values            
static void PrintList(List<string> MyList)
    {
        Console.WriteLine("Printing list using foreach loop:");
        foreach (var item in MyList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nPrinting list using ForEach method:");
        MyList.ForEach(Console.WriteLine);
        Console.WriteLine("\nPrinting list using for loop:");
        for (int i = 0; i < MyList.Count; i++)
        {
            Console.WriteLine(MyList[i]);
        }
    }
    List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
    PrintList(TestStringList);

                        // 2. Print Sum                
static void SumOfNumbers(List<int> IntList)
    {
        int sum = 0;
        foreach (var num in IntList)
        {
            sum += num;
        }
        Console.WriteLine($"Sum of numbers: {sum}");
    }
    static void CalculateSum()
    {
        List<int> TestIntList = new List<int>() {2, 7, 12, 9, 3};
        SumOfNumbers(TestIntList);
    }

CalculateSum();

                    // 3. Find Max             
static int FindMax(List<int> IntList)
{
    int max = IntList[0];
    foreach (var num in IntList)
    {
        if (num > max)
        {
            max = num;
        }
    }
    return max;
}
List<int> TestIntList2 = new List<int>() {-9, 12, 10, 3, 17, 5};
Console.WriteLine($"The maximum value is: {FindMax(TestIntList2)}");

                        // 4. Square the Values                
static List<int> SquareValues(List<int> IntList)
{
    List<int> squaredValues = new List<int>();
    foreach (var num in IntList)
    {
        squaredValues.Add(num * num);
    }
    return squaredValues;
}
List<int> TestIntList3 = new List<int>() {1, 2, 3, 4, 5};
List<int> squaredList = SquareValues(TestIntList3);

Console.WriteLine("Squared values:");
foreach (var squaredValue in squaredList)
{
    Console.WriteLine(squaredValue);
}
                    // 5. Replace Negative Numbers with 0                  
static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}

int[] TestIntArray = new int[] {-1, 2, 3, -4, 5};
int[] result = NonNegatives(TestIntArray);
foreach (int num in result)
{
    Console.Write(num + " ");
}

                    // 6. Print Dictionary                 
static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (var kvp in MyDictionary)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
}

Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

                        // 7. Find Key                 
static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm);
}
Console.WriteLine(FindKey(TestDict, "RealName"));
Console.WriteLine(FindKey(TestDict, "Name"));

                    // 8. Generate a Dictionary            
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> result = new Dictionary<string, int>();

    for (int i = 0; i < Names.Count; i++)
    {
        result.Add(Names[i], Numbers[i]);
    }

    return result;
}
List<string> names = new List<string>() { "Julie", "Harold", "James", "Monica" };
List<int> numbers = new List<int>() { 6, 12, 7, 10 };
Dictionary<string, int> generatedDict = GenerateDictionary(names, numbers);

foreach (var pair in generatedDict)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}

