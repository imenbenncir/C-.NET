
// Flip a coin
static string FlipCoin()
{
    var randomNumberGenerator = new Random();
    return randomNumberGenerator.Next(2) == 0 ? "Heads" : "Tails";
}
Console.WriteLine(FlipCoin());

// Roll a die
static int RollDie(int numberOfSides)
{
    var randomNumberGenerator = new Random();
    return randomNumberGenerator.Next(1, numberOfSides + 1);
}
Console.WriteLine(RollDie(6));

// Perform a stat roll
static List<int> PerformStatRoll()
{
    var results = new List<int>();
    for (int i = 0; i < 4; i++)
    {
        results.Add(RollDie(6));
    }
    return results;
}
Console.WriteLine(string.Join(", ", PerformStatRoll()));

// Roll until a target is reached
static string RollUntilTarget(int targetNumber, int numberOfSides)
{
    if (targetNumber > numberOfSides)
    {
        return "Please choose another number within the die's range.";
    }
    var randomNumberGenerator = new Random();
    int attempts = 0;
    int result;
    do
    {
        result = randomNumberGenerator.Next(1, numberOfSides + 1);
        attempts++;
    } while (result != targetNumber);

    return $"Achieved {targetNumber} after {attempts} rolls.";
}
Console.WriteLine(RollUntilTarget(3, 6));
