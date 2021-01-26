using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Kind of weapon. Looks like rocket, has cooldown.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rocket : Weapon
    {
        [SerializeField]
        private float acceleration;

        [SerializeField]
        private float weight;

        /// <summary>
        /// Time passed since last shot with this rocket after which rocket dissappears
        /// </summary>
        [SerializeField]
        private float lifetime;

        [SerializeField]
        private CooldownController cooldownController;

        private Rigidbody2D rocketRigidbody;
        private IPlanetsListController planetsListController;

        /// <summary>
        /// Time that passed since last shot with this rocket
        /// </summary>
        private float currentLifetime;

        /// <summary>
        /// Shoots with rocket if cooldown is over
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="direction"></param>
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
            weaponWorkingPart.transform.rotation = Quaternion.FromToRotation(Vector2.up, direction.normalized);// .LookRotation(Vector2.forward);// .Euler(, 0, 0);

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