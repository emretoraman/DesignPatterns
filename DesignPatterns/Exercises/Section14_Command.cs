namespace DesignPatterns.Exercises.Section14_Command
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
        public override string ToString()
        {
            return $"Action: {TheAction}, Amount: {Amount}, Succces: {Success}";
        }
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction) 
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    if (Balance < c.Amount) break;
                    Balance -= c.Amount;
                    c.Success = true;
                    break;
            }
        }
        public override string ToString()
        {
            return $"Balance: {Balance}";
        }
    }
}
