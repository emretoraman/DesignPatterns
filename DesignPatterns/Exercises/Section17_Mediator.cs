using System.Collections.Generic;

namespace DesignPatterns.Exercises.Section17_Mediator
{
    public class Participant
    {
        private readonly Mediator mediator;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            mediator.AddParticipant(this);
        }

        public void Say(int n)
        {
            mediator.Broadcast(this, n);
        }

        public override string ToString()
        {
            return $"Value: {Value}";
        }
    }

    public class Mediator
    {
        private readonly List<Participant> participants = new List<Participant>();

        public void AddParticipant(Participant participant)
        {
            participants.Add(participant);
        }

        public void Broadcast(Participant source, int n)
        {
            foreach (Participant p in participants)
            {
                if (p != source)
                {
                    p.Value += n;
                }
            }
        }
    }
}
