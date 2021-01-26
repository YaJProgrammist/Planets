using System;

namespace Gameplay
{
    /// <summary>
    /// Object that is an owner of some weapons
    /// </summary>
    public interface IShooter
    {
        /// <summary>
        /// Called when IShooter object is being destroyed
        /// </summary>
        event EventHandler OnShooterDestroy;
    }
}
