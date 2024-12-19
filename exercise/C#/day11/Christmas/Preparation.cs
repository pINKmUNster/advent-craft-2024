namespace Christmas
{
    public enum ToyType
    {
        Educational,
        Fun,
        Creative
    }

    public static class Preparation
    {
        public static string PrepareGifts(int numberOfGifts)
            => numberOfGifts switch
            {
                <= 0 => "No gifts to prepare.",
                < 50 => "Elves will prepare the gifts.",
                _ => "Santa will prepare the gifts."
            };

        public static string CategorizeGift(int age)
            => age switch
            {
                >= 0 and <= 2 => "Baby", // Survived
                > 2 and <= 5 => "Toddler", // Survived
                > 5 and <= 12 => "Child", // Survived
                _ => "Teen"
            };

        public static bool EnsureToyBalance(ToyType toyType, int toysCount, int totalToys)
            => ((double)toysCount / totalToys)
                .Do(typePercentage =>
                    toyType switch
                    {
                        ToyType.Educational => typePercentage >= 0.25,
                        ToyType.Fun => typePercentage >= 0.30,
                        ToyType.Creative => typePercentage >= 0.20,
                        _ => false // Missing coverage
                    });
    }
}