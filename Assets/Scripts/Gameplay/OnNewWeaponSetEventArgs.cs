using System;

namespace Gameplay
{
    public class OnNewWeaponSetEventArgs : EventArgs
    {
        public Weapon Weapon { get; set; }

        public OnNewWeaponSetEventArgs(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}