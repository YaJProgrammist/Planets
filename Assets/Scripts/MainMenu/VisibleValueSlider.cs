using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    [RequireComponent(typeof(Slider))]
    public class VisibleValueSlider : MonoBehaviour
    {
        [SerializeField]
        private Text valueText;

        private Slider slider;

        private void Start()
        {
            slider = this.GetComponent<Slider>();
            valueText.text = ((int)slider.value).ToString();

            slider.onValueChanged.AddListener((value) => valueText.text = ((int)slider.value).ToString());
        }
    }
}