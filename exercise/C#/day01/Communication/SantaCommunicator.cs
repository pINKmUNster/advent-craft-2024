namespace Communication
{
    public class SantaCommunicator(int numberOfDaysToRest, int numberOfDaysBeforeChristmas)
    {
        public string ComposeMessage(Reindeer reindeer)
        {
            var daysBeforeReturn = DaysBeforeReturn(reindeer.NumbersOfDaysForComingBack);
            return
                $"Dear {reindeer.Name}, please return from {reindeer.Location} in {daysBeforeReturn} day(s) to be ready and rest before Christmas.";
        }

        public bool IsOverdue(Reindeer reindeer, ILogger logger)
        {
            if (DaysBeforeReturn(reindeer.NumbersOfDaysForComingBack) <= 0)
            {
                logger.Log($"Overdue for {reindeer.Name} located {reindeer.Location}.");
                return true;
            }

            return false;
        }

        private int DaysBeforeReturn(int numbersOfDaysForComingBack) =>
            numberOfDaysBeforeChristmas - numbersOfDaysForComingBack - numberOfDaysToRest;
    }
}