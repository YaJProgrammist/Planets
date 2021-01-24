using System;
using UnityEngine;

namespace Gameplay
{
    public class PlanetsMover : MonoBehaviour
    {
        private IPlanetsListController planetsListController;
        private float timer;

        private void Awake()
        {
            timer = 0;
        }

        private void Start()
        {
            planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();
        }

        private void Update()
        {
            timer += Time.deltaTime;

            foreach (Planet planet in planetsListController.GetPlanetsList())
            {
                float angle = planet.GetInitialAngle() + planet.GetAnglePerSecond() * timer;

                Vector3 vectorFromSun = new Vector2();
                vectorFromSun.x = (float)(planet.GetOrbitalRadius() * Math.Sin(Mathf.Deg2Rad * angle));
                vectorFromSun.y = (float)(planet.GetOrbitalRadius() * Math.Cos(Mathf.Deg2Rad * angle));

                Vector3 planetPosition = planetsListController.GetSun().transform.position + vectorFromSun;
                planet.transform.position = planetPosition;
            }
        }
    }
}