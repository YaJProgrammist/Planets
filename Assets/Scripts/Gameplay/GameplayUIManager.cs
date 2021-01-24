using System;
using UnityEngine;

namespace Gameplay
{
    public class GameplayUIManager : MonoBehaviour
    {
        [SerializeField]
        private RectTransform gameplayPanel;

        [SerializeField]
        private RectTransform pausePanel;

        [SerializeField]
        private RectTransform gameOverPanel;

        [SerializeField]
        private RectTransform winPanel;

        public event EventHandler OnPaused;
        public event EventHandler OnResumed;

        private void Start()
        {
            PlanetsListController planetsListController = ServiceLocator.GetInstance().GetPlanetsListController();
            planetsListController.OnPlayerPlanetRemoved += (s, ea) => GameOver();
            planetsListController.OnAllEnemiesRemoved += (s, ea) => Win();
        }

        public void GoToMenu()
        {
            if (Time.timeScale != 1)
            {
                Time.timeScale = 1;
            }

            ScenesLoader.LoadMainMenu();
        }

        public void Pause()
        {
            Time.timeScale = 0;

            gameplayPanel.gameObject.SetActive(false);
            pausePanel.gameObject.SetActive(true);

            OnPaused?.Invoke(this, new EventArgs());
        }

        public void Resume()
        {
            Time.timeScale = 1;

            gameplayPanel.gameObject.SetActive(true);
            pausePanel.gameObject.SetActive(false);

            OnResumed?.Invoke(this, new EventArgs());
        }

        public void GameOver()
        {
            gameOverPanel.gameObject.SetActive(true);
        }

        public void Win()
        {
            winPanel.gameObject.SetActive(true);
        }
    }
}