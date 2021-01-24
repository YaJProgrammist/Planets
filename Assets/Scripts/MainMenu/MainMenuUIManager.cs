using System;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuUIManager : MonoBehaviour
    {
        [SerializeField]
        private RectTransform settingsPanel;

        public event EventHandler OnOpenSettings;

        public void StartGame()
        {
            ScenesLoader.LoadGameplay();
        }

        public void OpenSettings()
        {
            settingsPanel.gameObject.SetActive(true);
        }

        public void CloseSettings()
        {
            settingsPanel.gameObject.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}