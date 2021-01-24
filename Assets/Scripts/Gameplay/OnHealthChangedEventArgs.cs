using System;

namespace Gameplay
{
    public class OnHealthChangedEventArgs : EventArgs
    {
        public float Health { get; set; }

        public OnHealthChangedEventArgs(float health)
        {
            Health = health;
        }
    }
}