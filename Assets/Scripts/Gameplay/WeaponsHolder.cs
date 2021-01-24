using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class WeaponsHolder : MonoBehaviour
    {
        [SerializeField]
        private List<Weapon> weaponPrefabs;

        public Weapon GetRandomWeaponPrefab()
        {
            if (weaponPrefabs.Count == 0)
            {
                return null;
            }

            return weaponPrefabs[Random.Range(0, weaponPrefabs.Count)];
        }
    }
}
