using System;

namespace Gameplay
{
    public class OnTargetReachedEventArgs : EventArgs
    {
        public float Damage { get; set; }

        public OnTargetReachedEventArgs(float damage)
        {
            Damage = damage;
        }
    }
}