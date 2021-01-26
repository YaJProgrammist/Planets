using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Responsible for shooting tactics of enemy planets
    /// </summary>
    public class EnemyPlanetAI : MonoBehaviour
    {
        [SerializeField]
        private PlanetShootController planetShootController;

        /// <summary>
        /// Count of attempts to shoot (per minute)
        /// </summary>
        [SerializeField]
        private float shotAttemptsPerMinute;

        /// <summary>
        /// Count of attempts to shoot that are meant to hit player planet (per minute)
        /// </summary>
        [SerializeField]
        private float succsessesPerMinute;

        /// <summary>
        /// Point from which shots are done
        /// </summary>
        [SerializeField]
        private Transform shotPoint;

        private IPlanetsListController planetsListController;

        private void Start()
        {
            planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();
        }

        private void FixedUpdate()
        {
            //get random number from range of count of FixedUpdates per minute
            float ifShoot = Random.Range(0, 60 / Time.fixedDeltaTime);

            //in shotAttemptsPerMinute cases try to shoot
            if (ifShoot <= shotAttemptsPerMinute)
            {
                Vector2 shotDirection;

                //get random number from range of count of shot attempts per minute
                float ifSuccsess = Random.Range(0, shotAttemptsPerMinute);

                //in succsessesPerMinute cases try to make a shot successful
                //in other cases try to make random shot
                if (ifSuccsess <= succsessesPerMinute)
                {
                    Vector2 playerPlanetPosition = planetsListController.GetPlayerPlanet().transform.position;
                    shotDirection = playerPlanetPosition - (Vector2)shotPoint.position;
                }
                else
                {
                    shotDirection = Random.insideUnitCircle.normalized;
                }

                planetShootController.MakeShot(shotDirection);
            }
        }
    }
}
