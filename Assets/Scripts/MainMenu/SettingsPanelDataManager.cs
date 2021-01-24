using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class SettingsPanelDataManager : MonoBehaviour
    {
        [SerializeField]
        private Slider minEnemyPlanetsCountSlider;

        [SerializeField]
        private Slider maxEnemyPlanetsCountSlider;

        private void Start()
        {
            minEnemyPlanetsCountSlider.value = SettingsManager.MinEnemyPlanetsCount;
            maxEnemyPlanetsCountSlider.value = SettingsManager.MaxEnemyPlanetsCount;
        }

        public void SaveSettings()
        {
            SettingsManager.MinEnemyPlanetsCount = (int)minEnemyPlanetsCountSlider.value;
            SettingsManager.MaxEnemyPlanetsCount = (int)maxEnemyPlanetsCountSlider.value;
        }
    }
}
