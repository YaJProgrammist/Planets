using System;
using UnityEngine;

namespace Gameplay
{
    public class Planet : MonoBehaviour, IHittable, IShooter
    {
        [SerializeField]
        private float weight;

        /// <summary>
        /// Initial angle of rotation around the sun
        /// </summary>
        [SerializeField]
        private float initialAngle;

        /// <summary>
        /// Angle of rotation around the sun per second
        /// </summary>
        [SerializeField]
        private float anglePerSecond;

        /// <summary>
        /// Radius of planet orbit (= distance from sun)
        /// </summary>
        [SerializeField]
        private float orbitalRadius;

        private float health;

        public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
        public event EventHandler OnShooterDestroy;

        private void Start()
        {
            health = 1;
            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs(health));
        }

        /// <summary>
        /// Set planet parameters. Required to make planet look properly
        /// </summary>
        /// <param name="weightVal"></param>
        /// <param name="initialAngleVal"></param>
        /// <param name="anglePerSecondVal"></param>
        /// <param name="orbitalRadiusVal"></param>
        public void Initialize(float weightVal, float initialAngleVal, float anglePerSecondVal, float orbitalRadiusVal)
        {
            weight = weightVal;
            initialAngle = initialAngleVal;
            anglePerSecond = anglePerSecondVal;
            orbitalRadius = orbitalRadiusVal;
        }

        public void Hit(float damage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs(health));

            if (health <= 0)
            {
                OnShooterDestroy?.Invoke(this, new EventArgs());
                Destroy(this.gameObject);
            }
        }

        public float GetWeight()
        {
            return weight;
        }

        public float GetInitialAngle()
        {
            return initialAngle;
        }

        public float GetAnglePerSecond()
        {
            return anglePerSecond;
        }

        public float GetOrbitalRadius()
        {
            return orbitalRadius;
        }
    }
}