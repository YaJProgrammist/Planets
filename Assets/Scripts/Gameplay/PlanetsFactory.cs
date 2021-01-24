using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
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
            float weight = 2; //TODO this all
            float initialAngle = Random.Range(0, 360);
            float anglePerSecond = Random.Range(10, 45);
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