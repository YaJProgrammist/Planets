using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Object that represents the center of planets system
    /// </summary>
    public class Sun : MonoBehaviour, IHittable
    {
        [SerializeField]
        private float weight;

        public float GetWeight()
        {
            return weight;
        }

        public void Hit(float damage)
        {
            //nothing should be here
        }
    }
}
