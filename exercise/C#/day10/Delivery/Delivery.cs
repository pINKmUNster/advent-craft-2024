namespace Delivery
{
    public static class Building
    {
        // 3.  ()) = -1
        // 2. (()(()( = 3 
        // 5. )())()) = -3
        // 7. 🧝) =  1
        // 8. 🧝)( = -1

        public static int WhichFloor(string instructions)
        {
            var containsElf = instructions.Contains("🧝");
            var calculatedFloors = instructions.Select(c => CalculateFloor(c, containsElf)).ToList();
            var result = ComputeResult(calculatedFloors);
            return result;
        }

        private static Tuple<char, int> CalculateFloor(char c, bool containsElf)
        {
            if (containsElf)
            {
                return new Tuple<char, int>(c, CalculateFloorWithElf(c));
            }

            return new Tuple<char, int>(c, CalculateFloorWithoutElf(c));
        }

        private static int CalculateFloorWithoutElf(char c)
            => c switch
            {
                '(' => 1,
                ')' => -1,
                _ => 0
            };

        private static int CalculateFloorWithElf(char c)
            => c switch
            {
                '(' => -2,
                ')' => 3,
                _ => 0
            };

        private static int ComputeResult(List<Tuple<char, int>> val)
            => val.Sum(kp => kp.Item2);
    }
}