using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Exercises.Section18_Memento
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            Value = value;
        }
    }

    public class Memento
    {
        public Dictionary<Token, int> Tokens { get; }
        public Memento(Dictionary<Token, int> tokens)
        {
            Tokens = tokens;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));
            return new Memento(Tokens.ToDictionary(t => t, t => t.Value));
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return new Memento(Tokens.ToDictionary(t => t, t => t.Value));
        }

        public void Revert(Memento m)
        {
            Tokens.Clear();
            foreach (var tv in m.Tokens)
            {
                tv.Key.Value = tv.Value;
                Tokens.Add(tv.Key);
            }
        }
    }
}
