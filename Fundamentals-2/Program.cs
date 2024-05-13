
        // ********Array****//

int[] integerArray = new int[10];
for (int i = 0; i < 10; i++)
{
    integerArray[i] = i;
    Console.WriteLine(integerArray[i]);
}

string[] stringArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };
for (int i = 0; i < stringArray.Length; i++)
{
    Console.WriteLine(stringArray[i]);
}

bool[] booleanArray = new bool[10];
bool value = true;
for (int i = 0; i < booleanArray.Length; i++)
{
    booleanArray[i] = value;
    value = !value;
    Console.WriteLine(booleanArray[i]);
}

            // ********List****// 

List<string> iceCreamFlavors = new List<string> ();

iceCreamFlavors.Add("Vanilla");
iceCreamFlavors.Add("Chocolate");
iceCreamFlavors.Add("Strawberry");
iceCreamFlavors.Add("Mint");
iceCreamFlavors.Add("Cookie Dough");

Console.WriteLine("The length of the list after adding flavors: " + iceCreamFlavors.Count);

Console.WriteLine("The third flavor in the list: " + iceCreamFlavors[2]);

iceCreamFlavors.RemoveAt(2);

Console.WriteLine("The length of the list after removal: " + iceCreamFlavors.Count);
    
            // ********Dictionary****//

Dictionary<string, string> iceCreamPreferences = new Dictionary<string, string>();

string[] names = { "Alice", "Bob", "Charlie", "David", "Eve" };

string[] flavors = { "Vanilla", "Chocolate", "Strawberry", "Mint", "Cookie Dough" };

int flavorIndex = 0;

foreach (string name in names)
    {
        iceCreamPreferences.Add(name, flavors[flavorIndex]);

        flavorIndex++;

        if (flavorIndex >= flavors.Length)
            {
                flavorIndex = 0;
            }
    }

Console.WriteLine("Ice Cream Preferences:");
foreach (KeyValuePair<string, string> entry in iceCreamPreferences)
        {
            Console.WriteLine($"{entry.Key} - {entry.Value}");
        }
