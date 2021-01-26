using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class PlanetHUD : MonoBehaviour
    {
        [SerializeField]
        private Slider hpSlider;

        /// <summary>
        /// UI text field supposed to hold cooldown value
        /// </summary>
        [SerializeField]
        private Text cooldownText;

        [SerializeField]
        private Planet planet;

        [SerializeField]
        private PlanetShootController planetShootController;

        private void Start()
        {
            planet.OnHealthChanged += (s, ea) => hpSlider.value = ea.Health;
            planetShootController.OnNewWeaponSet += (s, ea) => SubscribeToWeaponCooldown(ea.Weapon);
        }

        /// <summary>
        /// Binds cooldownText value with actual value of weapon cooldown
        /// </summary>
        /// <param name="weapon"></param>
        private void SubscribeToWeaponCooldown(Weapon weapon)
        {
            CooldownController cooldownController = weapon.GetComponent<CooldownController>();
            if (cooldownController != null)
            {
                cooldownController.OnCooldownChanged += (s, ea) => cooldownText.text = ea.Cooldown + "s";
            }
            else
            {
                cooldownText.text = "0s";
            }
        }
    }
}