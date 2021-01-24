using System;
using UnityEngine;

namespace Gameplay
{
    public class Planet : MonoBehaviour, IHittable, IShooter
    {
        [SerializeField]
        private float weight;

        [SerializeField]
        private float initialAngle;

        [SerializeField]
        private float anglePerSecond;

        [SerializeField]
        private float orbitalRadius;

        private float health;
        private IPlanetsListController planetsListController;

        public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
        public event EventHandler OnShooterDestroy;

        private void Start()
        {
            health = 1;
            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs(health));

            planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();
        }

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