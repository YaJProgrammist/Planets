using UnityEngine;

namespace Gameplay
{
    public class EnemyPlanetAI : MonoBehaviour
    {
        [SerializeField]
        private PlanetShootController planetShootController;

        [SerializeField]
        private float shotAttemptsPerMinute;

        [SerializeField]
        private float succsessesPerMinute;

        [SerializeField]
        private Transform shotPoint;

        private IPlanetsListController planetsListController;

        private void Start()
        {
            planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();
        }

        private void FixedUpdate()
        {
            int ifShoot = Random.Range(0, (int)(60 / Time.fixedDeltaTime));

            if (ifShoot <= shotAttemptsPerMinute)
            {
                Vector2 shotDirection;

                int ifSuccsess = Random.Range(0, (int)(60 / Time.fixedDeltaTime));
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
