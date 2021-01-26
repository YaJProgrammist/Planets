using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Object that can be activated with IShooter to hit some IHitterables
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected WeaponWorkingPart weaponWorkingPart;

        /// <summary>
        /// Damage that is done to hit object
        /// </summary>
        [SerializeField]
        private float damage;

        protected IShooter shooter;

        public event EventHandler<OnTargetReachedEventArgs> OnTargetReached;

        private void HandleCollision(GameObject collisionObject)
        {
            if (collisionObject.GetComponent<IShooter>() == shooter)
            {
                return;
            }

            OnTargetReached?.Invoke(this, new OnTargetReachedEventArgs(damage));

            Hit(collisionObject);
        }

        public void Initialize(GameObject shooterObj)
        {
            shooter = shooterObj.GetComponent<IShooter>();

            if (shooter != null)
            {
                shooter.OnShooterDestroy += (s, ea) => Destroy(this);
            }
        }

        public void Show()
        {
            weaponWorkingPart.gameObject.SetActive(true);
        }

        public void Hide()
        {
            weaponWorkingPart.gameObject.SetActive(false);
        }

        private void Hit(GameObject collisionObject)
        {
            IHittable target = collisionObject.GetComponent<IHittable>();
            target?.Hit(damage);
        }

        public abstract void TryActivate(Vector2 startPosition, Vector2 direction);

        protected void Start()
        {
            weaponWorkingPart.OnWorkingPartTriggered += (s, ea) => HandleCollision(ea.CollisionObject);
        }
    }
}