namespace DesignPatterns.Exercises.Section21_StateMachine
{
    public class CombinationLock
    {
        private readonly int[] combination;
        public CombinationLock(int[] combination)
        {
            this.combination = combination;
            Status = "LOCKED";
        }

        public string Status;

        public void EnterDigit(int digit)
        {
            switch (Status)
            {
                case "LOCKED":
                case "ERROR":
                    Status = "";
                    goto default;
                case "OPEN":
                    break;
                default:
                    Status = combination[Status.Length] == digit ? Status + digit.ToString() : "ERROR";
                    Status = Status.Length == combination.Length ? "OPEN" : Status;
                    break;
            }
        }
    }
}
