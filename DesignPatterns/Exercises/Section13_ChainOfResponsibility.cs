using System.Collections.Generic;

namespace DesignPatterns.Exercises
{
    public class Section13_ChainOfResponsibility
    {
        public abstract class Creature
        {
            protected readonly Game game;
            private readonly int attack;
            private readonly int defense;
            public virtual int Attack => attack;
            public virtual int Defense => defense;

            public Creature(Game game, int attack, int defense)
            {
                this.game = game;
                this.attack = attack;
                this.defense = defense;
            }
        }

        public class Goblin : Creature
        {
            public override int Attack 
            {
                get 
                {
                    var attack = base.Attack;
                    foreach (var creature in game.Creatures)
                    {
                        if (creature is GoblinKing && !ReferenceEquals(this, creature))
                        {
                            attack += 1;
                        }
                    }
                    return attack;
                }
            }

            public override int Defense
            {
                get
                {
                    var defense = base.Defense;
                    foreach (var creature in game.Creatures)
                    {
                        if (creature is Goblin && !ReferenceEquals(this, creature))
                        {
                            defense += 1;
                        }
                    }
                    return defense;
                }
            }

            public Goblin(Game game) : base(game, 1, 1) { }

            public Goblin(Game game, int attack, int defense) : base(game, attack, defense) { }

            public override string ToString()
            {
                return $"Goblin, Attack: {Attack}, Defense: {Defense}";
            }
        }

        public class GoblinKing : Goblin
        {
            public GoblinKing(Game game) : base(game, 3, 3) { }
            public override string ToString()
            {
                return $"GoblinKing, Attack: {Attack}, Defense: {Defense}";
            }
        }

        public class Game
        {
            public IList<Creature> Creatures = new List<Creature>();
        }
    }
}
