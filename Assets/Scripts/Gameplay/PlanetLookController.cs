using UnityEngine;

namespace Gameplay
{ 
    /// <summary>
    /// Responsible for planet appearance
    /// </summary>
    public class PlanetLookController : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer planetSpriteRenderer;

        public void SetSprite(Sprite sprite)
        {
            planetSpriteRenderer.sprite = sprite;
        }
    }
}