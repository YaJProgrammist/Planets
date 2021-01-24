using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    [RequireComponent(typeof(Slider))]
    public class MaxValueSlider : MonoBehaviour
    {
        [SerializeField]
        private Slider minValueSlider;

        private Slider slider;

        private void Start()
        {
            slider = this.GetComponent<Slider>();

            CorrectValue();

            minValueSlider.onValueChanged.AddListener((v) => CorrectValue());
            slider.onValueChanged.AddListener((v) => CorrectValue());
        }

        private void CorrectValue()
        {
            if (slider.value < minValueSlider.value)
            {
                slider.value = minValueSlider.value;
            }
        }
    }
}