using UnityEngine;

public class PlanetLookController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer planetSpriteRenderer;

    public void SetSprite(Sprite sprite)
    {
        planetSpriteRenderer.sprite = sprite;
    }
}
