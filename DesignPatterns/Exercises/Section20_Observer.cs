using System;

namespace DesignPatterns.Exercises.Section20_Observer
{
    public class Game
    {
        public event EventHandler RatJoined;
        public event EventHandler RatDied;

        public void InvokeRatJoined(Rat sender)
        {
            RatJoined?.Invoke(sender, EventArgs.Empty);
        }
        public void InvokeRatDied()
        {
            RatDied?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Rat : IDisposable
    {
        private readonly Game game;
        public int Attack = 1;

        public Rat(Game game)
        {
            this.game = game;
            game.InvokeRatJoined(this);
            game.RatJoined += Game_RatJoined;
            game.RatDied += Game_RatDied;
        }

        private void Game_RatJoined(object sender, EventArgs e)
        {
            if (sender is Rat rat) rat.Attack++;
            Attack++;
        }

        private void Game_RatDied(object sender, EventArgs e)
        {
            Attack--;
        }

        public void Dispose()
        {
            game.RatDied -= Game_RatDied;
            game.RatJoined -= Game_RatJoined;
            game.InvokeRatDied();
            GC.SuppressFinalize(this);
        }
    }
}
