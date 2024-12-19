namespace ToyProduction.Domain
{
    public class Toy(string name)
    {
        public string Name { get; } = name;
        public State State { get; private set; } = State.Unassigned;

        public void AssignToElf()
        {
            if (State == State.Unassigned)
            {
                State = State.InProduction;
            }
        }
    }

    public enum State
    {
        Unassigned,
        InProduction,
        Completed
    }
}