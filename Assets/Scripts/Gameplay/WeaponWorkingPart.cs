using System;
using UnityEngine;

namespace Gameplay
{
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
