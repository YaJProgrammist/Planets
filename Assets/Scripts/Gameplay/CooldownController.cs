using System;
using UnityEngine;

namespace Gameplay
{
    public class CooldownController : MonoBehaviour
    {
        [SerializeField]
        private int cooldownSec;

        private float currentCooldown;
        private GameTimeController gameTimeController;

        public event EventHandler<OnCooldownChangedEventArgs> OnCooldownChanged;

        private void Start()
        {
            currentCooldown = 0;
            OnCooldownChanged?.Invoke(this, new OnCooldownChangedEventArgs((int)currentCooldown));

            gameTimeController = ServiceLocator.GetInstance().GetGameTimeController();
        }

        private void Update()
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
                return;
            }

            currentCooldown -= Time.fixedDeltaTime * gameTimeController.GetTimeScale();
            OnCooldownChanged?.Invoke(this, new OnCooldownChangedEventArgs((int)currentCooldown));
        }

        public void RestartCooldownCounter()
        {
            currentCooldown = cooldownSec;
            OnCooldownChanged?.Invoke(this, new OnCooldownChangedEventArgs((int)currentCooldown));
        }

        public bool CooldownExpired()
        {
            return (currentCooldown == 0);
        }
    }
}