namespace Communication
{
    public class SantaCommunicator(int numberOfDaysToRest)
    {
        public string ComposeMessage(Reindeer reindeer)
        {
            var daysBeforeReturn = DaysBeforeReturn(reindeer.NumbersOfDaysForComingBack, reindeer.NumberOfDaysBeforeChristmas);
            return
                $"Dear {reindeer.ReindeerName}, please return from {reindeer.CurrentLocation} in {daysBeforeReturn} day(s) to be ready and rest before Christmas.";
        }

        public bool IsOverdue(Reindeer reindeer, ILogger logger)
        {
            if (DaysBeforeReturn(reindeer.NumbersOfDaysForComingBack, reindeer.NumberOfDaysBeforeChristmas) <= 0)
            {
                logger.Log($"Overdue for {reindeer.ReindeerName} located {reindeer.CurrentLocation}.");
                return true;
            }

            return false;
        }

        private int DaysBeforeReturn(int numbersOfDaysForComingBack, int numberOfDaysBeforeChristmas) =>
            numberOfDaysBeforeChristmas - numbersOfDaysForComingBack - numberOfDaysToRest;
    }
}