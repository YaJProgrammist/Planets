using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Singleton service that provides access to other services that are meant to also be single
    /// </summary>
    public class ServiceLocator : MonoBehaviour
    {
        [SerializeField]
        private PlanetsListController planetsListController;

        [SerializeField]
        private WeaponsGenerator weaponsGenerator;

        private static ServiceLocator instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public static ServiceLocator GetInstance()
        {
            return instance;
        }

        public PlanetsListController GetPlanetsListController()
        {
            return planetsListController;
        }

        public WeaponsGenerator GetWeaponsGenerator()
        {
            return weaponsGenerator;
        }
    }
}
