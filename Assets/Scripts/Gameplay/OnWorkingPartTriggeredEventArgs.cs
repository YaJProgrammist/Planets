using System;
using UnityEngine;

namespace Gameplay
{
    public class OnWorkingPartTriggeredEventArgs : EventArgs
    {
        public GameObject CollisionObject { get; set; }

        public OnWorkingPartTriggeredEventArgs(GameObject collisionObject)
        {
            CollisionObject = collisionObject;
        }
    }
}