using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PlanetsListController : MonoBehaviour, IPlanetsListController
    {
        [SerializeField]
        private Sun sun;

        [SerializeField]
        private PlanetsFactory planetsFactory;

        private List<Planet> planets;
        private Planet playerPlanet;

        public event EventHandler OnPlayerPlanetRemoved;
        public event EventHandler OnAllEnemiesRemoved;

        private void Awake()
        {
            planets = new List<Planet>();
        }

        private void Start()
        {
            InitializePlanetsList();
        }

        public IReadOnlyCollection<Planet> GetPlanetsList()
        {
            return planets.AsReadOnly();
        }

        public Sun GetSun()
        {
            return sun;
        }

        public Planet GetPlayerPlanet()
        {
            return playerPlanet;
        }

        private void InitializePlanetsList()
        {
            int minEnemyPlanetsCount = SettingsManager.MinEnemyPlanetsCount;
            int maxEnemyPlanetsCount = SettingsManager.MaxEnemyPlanetsCount;

            int enemyPlanetsCount = UnityEngine.Random.Range(minEnemyPlanetsCount, maxEnemyPlanetsCount);
            int playerPlanetPosition = UnityEngine.Random.Range(0, enemyPlanetsCount + 1);

            for (int planetPosition = 0; planetPosition < enemyPlanetsCount + 1; planetPosition++)
            {
                Planet newPlanet;

                if (planetPosition != playerPlanetPosition)
                {
                    newPlanet = planetsFactory.CreateEnemyPlanet(planetPosition);
                }
                else
                {
                    newPlanet = planetsFactory.CreatePlayerPlanet(planetPosition);
                    playerPlanet = newPlanet;
                }

                newPlanet.OnShooterDestroy += (s, ea) => RemovePlanet(newPlanet);

                planets.Add(newPlanet);
            }
        }

        private void RemovePlanet(Planet planet)
        {
            planets.Remove(planet);

            if (planet == playerPlanet)
            {
                OnPlayerPlanetRemoved?.Invoke(this, new EventArgs());
                return;
            }

            if (planets.Count == 1)
            {
                OnAllEnemiesRemoved?.Invoke(this, new EventArgs());
            }
        }
    }
}