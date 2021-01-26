using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Generates random weapons from prefabs
    /// </summary>
    public class WeaponsGenerator : MonoBehaviour
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
