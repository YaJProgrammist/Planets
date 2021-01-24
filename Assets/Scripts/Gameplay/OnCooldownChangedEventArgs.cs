using System;

namespace Gameplay
{
    public class OnCooldownChangedEventArgs : EventArgs
    {
        public int Cooldown { get; set; }

        public OnCooldownChangedEventArgs(int cooldown)
        {
            Cooldown = cooldown;
        }
    }
}