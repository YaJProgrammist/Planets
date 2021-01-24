using UnityEngine;

namespace Gameplay
{
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
        }
    }
}