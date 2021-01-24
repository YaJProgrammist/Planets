using UnityEngine;

namespace Gameplay
{
    public class ServiceLocator : MonoBehaviour
    {
        [SerializeField]
        private PlanetsListController planetsListController;

        [SerializeField]
        private WeaponsHolder weaponsHolder;

        [SerializeField]
        private GameTimeController gameTimeController;

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

        public GameTimeController GetGameTimeController()
        {
            return gameTimeController;
        }

        public WeaponsHolder GetWeaponsHolder()
        {
            return weaponsHolder;
        }
    }
}
