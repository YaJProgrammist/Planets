using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Recognizes player input that is meant to make player planet shoot
    /// </summary>
    public class ShootInputReceiver : MonoBehaviour
    {
        [SerializeField]
        private PlanetShootController planetShootController;

        private void Update()
        {
            if (Input.GetButtonUp("Shoot"))
            {
                Vector2 shotDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized;
                planetShootController.MakeShot(shotDirection);
            }

            if (Input.touchCount > 0)
            {
                Vector2 shotDirection = (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - this.transform.position).normalized;
                planetShootController.MakeShot(shotDirection);
            }
        }
    }
}