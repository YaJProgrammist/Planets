using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// 
    /// </summary>
    public class CooldownController : MonoBehaviour
    {
        [SerializeField]
        private int cooldownSec;

        private float currentCooldown;

        public event EventHandler<OnCooldownChangedEventArgs> OnCooldownChanged;

        private void Start()
        {
            currentCooldown = 0;
            OnCooldownChanged?.Invoke(this, new OnCooldownChangedEventArgs((int)currentCooldown));
        }

        private void Update()
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
                return;
            }

            currentCooldown -= Time.fixedDeltaTime * Time.timeScale;
            OnCooldownChanged?.Invoke(this, new OnCooldownChangedEventArgs((int)currentCooldown));
        }

        /// <summary>
        /// 
        /// </summary>
        public void RestartCooldownCounter()
        {
            currentCooldown = cooldownSec;
            OnCooldownChanged?.Invoke(this, new OnCooldownChangedEventArgs((int)currentCooldown));
        }

        /// <summary>
        /// True - 
        /// </summary>
        /// <returns></returns>
        public bool CooldownExpired()
        {
            return (currentCooldown == 0);
        }
    }
}