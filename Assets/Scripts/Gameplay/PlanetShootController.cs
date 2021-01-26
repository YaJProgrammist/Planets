using System;
using UnityEngine;

namespace Gameplay
{
    public class PlanetShootController : MonoBehaviour
    {
        [SerializeField]
        private GameObject shooter;

        [SerializeField]
        private Weapon weaponPrefab;

        [SerializeField]
        private GameObject shotPoint;

        private Weapon weapon;

        public event EventHandler<OnNewWeaponSetEventArgs> OnNewWeaponSet;

        private void Start()
        {
            weaponPrefab = ServiceLocator.GetInstance().GetWeaponsGenerator().GetRandomWeaponPrefab();

            if (weaponPrefab != null)
            {
                SetNewWeapon(weaponPrefab);
            }
        }

        public void SetNewWeapon(Weapon newWeapon)
        {
            weaponPrefab = newWeapon;
            InitializeWeapon();

            OnNewWeaponSet?.Invoke(this, new OnNewWeaponSetEventArgs(weapon));
        }

        public void MakeShot(Vector2 direction)
        {
            weapon.TryActivate(shotPoint.transform.position, direction);
        }

        private void InitializeWeapon()
        {
            weapon = Instantiate(weaponPrefab);
            weapon.transform.position = shotPoint.transform.position;
            weapon.Initialize(shooter);
            weapon.Hide();

            weapon.OnTargetReached += (s, ea) => weapon.Hide();
        }
    }
}