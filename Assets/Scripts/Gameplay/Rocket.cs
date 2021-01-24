using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rocket : Weapon
    {
        [SerializeField]
        private float acceleration;

        [SerializeField]
        private float weight;

        [SerializeField]
        private float lifetime;

        [SerializeField]
        private CooldownController cooldownController;

        private Rigidbody2D rocketRigidbody;
        private IPlanetsListController planetsListController;
        private float currentLifetime;

        public override void TryActivate(Vector2 startPosition, Vector2 direction)
        {
            if (!cooldownController.CooldownExpired())
            {
                return;
            }

            this.transform.position = startPosition;
            this.Show();

            currentLifetime = 0;

            //Vector2 shotForce = weight * acceleration * direction.normalized * 100;
            rocketRigidbody.velocity = acceleration * direction.normalized;

            //PARABOLIC MOVEMENT HAD TO BE HERE
            /*Sun sun = planetsListController.GetSun();
            Vector2 sunForce = sun.GetWeight() * weight * ;
            rocketRigidbody.AddForce(weight * acceleration * startVelocity.normalized);

            foreach (Planet planet in planetsListController.GetPlanetsList())
            {
                Vector2 distanceVector = planet.transform.position - this.transform.position;
                Vector2 force = Vector2.one * weight * planet.GetWeight() / distanceVector;
                rocketRigidbody.AddForce(force);
            }*/

            cooldownController.RestartCooldownCounter();
        }

        private new void Start()
        {
            base.Start();

            rocketRigidbody = this.GetComponent<Rigidbody2D>();

            planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();

            currentLifetime = 0;
        }

        private void Update()
        {
            currentLifetime += Time.deltaTime;

            if (currentLifetime >= lifetime)
            {
                Hide();
            }
        }
    }
}