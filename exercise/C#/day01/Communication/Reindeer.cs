namespace Communication;

public class Reindeer(
    string reindeerName,
    string currentLocation,
    int numbersOfDaysForComingBack,
    int numberOfDaysBeforeChristmas)
{
    public string ReindeerName { get; private set; } = reindeerName;
    public string CurrentLocation { get; private set; } = currentLocation;
    public int NumbersOfDaysForComingBack { get; private set; } = numbersOfDaysForComingBack;
    public int NumberOfDaysBeforeChristmas { get; private set; } = numberOfDaysBeforeChristmas;
}