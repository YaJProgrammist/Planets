using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Responsible for rotation of planet around the sun
    /// </summary>
    public class PlanetMover : MonoBehaviour
    {
        private PlanetsListController planetsListController;

        [SerializeField]
        private Planet planet;

        /// <summary>
        /// Timer that defines current angle of planet rotation around the sun
        /// </summary>
        private float timer;

        /// <summary>
        /// Time in which planet makes full circle
        /// </summary>
        private float fullCircleTime;

        private void Awake()
        {
            timer = 0;
        }

        private void Start()
        {
            planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();

            fullCircleTime = 360 / planet.GetAnglePerSecond();
        }

        private void Update()
        {
            timer = (timer + Time.deltaTime) % fullCircleTime;

            //current angle of planet rotation around the sun
            float angle = (planet.GetInitialAngle() + planet.GetAnglePerSecond() * timer) % 360;

            //current planet offset relative to the sun
            Vector3 vectorFromSun = new Vector2();
            vectorFromSun.x = (float)(planet.GetOrbitalRadius() * Math.Sin(Mathf.Deg2Rad * angle));
            vectorFromSun.y = (float)(planet.GetOrbitalRadius() * Math.Cos(Mathf.Deg2Rad * angle));

            Vector3 planetPosition = planetsListController.GetSun().transform.position + vectorFromSun;
            planet.transform.position = planetPosition;
        }
    }
}