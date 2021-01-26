using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Responsible for UI operations of GameplayScene
    /// </summary>
    public class GameplayUIManager : MonoBehaviour
    {
        /// <summary>
        /// Panel to show during the game going on
        /// </summary>
        [SerializeField]
        private RectTransform gameplayPanel;

        /// <summary>
        /// Panel to show while game is paused
        /// </summary>
        [SerializeField]
        private RectTransform pausePanel;

        /// <summary>
        /// Panel that informs player about his failure
        /// </summary>
        [SerializeField]
        private RectTransform gameOverPanel;

        /// <summary>
        /// Panel that informs player about his victory
        /// </summary>
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
            gameplayPanel.gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
        }

        public void Win()
        {
            gameplayPanel.gameObject.SetActive(false);
            winPanel.gameObject.SetActive(true);
        }
    }
}