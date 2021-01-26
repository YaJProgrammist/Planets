using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Responsible for creating planets of different types
    /// </summary>
    public class PlanetsFactory : MonoBehaviour
    {
        [SerializeField]
        private Planet enemyPlanetPrefab;

        [SerializeField]
        private List<Sprite> enemyPlanetSprites;

        [SerializeField]
        private Planet playerPlanetPrefab;

        [SerializeField]
        private float distanceBetweenOrbits;

        [SerializeField]
        private float planetWeight;

        [SerializeField]
        private float minAnglePerSecond;

        [SerializeField]
        private float maxAnglePerSecond;

        public Planet CreateEnemyPlanet(int planetPosition)
        {
            Planet planet = CreatePlanet(enemyPlanetPrefab, planetPosition);

            TrySetPlanetSprite(planet, enemyPlanetSprites[Random.Range(0, enemyPlanetSprites.Count)]);

            return planet;
        }

        public Planet CreatePlayerPlanet(int planetPosition)
        {
            Planet planet = CreatePlanet(playerPlanetPrefab, planetPosition);

            return planet;
        }

        private Planet CreatePlanet(Planet prefab, int planetPosition)
        {
            Planet planet = Instantiate(prefab);
            float weight = planetWeight; 
            float initialAngle = Random.Range(0, 360);
            float anglePerSecond = Random.Range(minAnglePerSecond, maxAnglePerSecond);
            float distanceFromSun = (planetPosition + 1) * distanceBetweenOrbits;
            planet.Initialize(weight, initialAngle, anglePerSecond, distanceFromSun);
            return planet;
        }

        private void TrySetPlanetSprite(Planet planet, Sprite sprite)
        {
            PlanetLookController lookController = planet.GetComponent<PlanetLookController>();
            lookController?.SetSprite(sprite);
        }
    }
}