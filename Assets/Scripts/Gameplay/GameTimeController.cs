using UnityEngine;

namespace Gameplay
{
    public class GameTimeController : MonoBehaviour
    {
        [SerializeField]
        private GameplayUIManager uiManager;

        private float gameTimeScale;

        private void Awake()
        {
            gameTimeScale = 1;
        }

        private void Start()
        {
            uiManager.OnPaused += (s, ea) => gameTimeScale = 0;
            uiManager.OnResumed += (s, ea) => gameTimeScale = 1;
        }

        public float GetTimeScale()
        {
            return gameTimeScale;
        }
    }
}
