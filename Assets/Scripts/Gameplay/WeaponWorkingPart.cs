using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Part of weapon that is shown and detects hits
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class WeaponWorkingPart : MonoBehaviour
    {
        public event EventHandler<OnWorkingPartTriggeredEventArgs> OnWorkingPartTriggered;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            GameObject collisionObject = collider.gameObject;
            OnWorkingPartTriggered?.Invoke(this, new OnWorkingPartTriggeredEventArgs(collisionObject));
        }
    }
}
