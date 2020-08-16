using UnityEngine;

namespace PocketProjects.BulletHell
{
    public class Bullet : MonoBehaviour
    {
        private float movementSpeed;
        private Vector2 movementDirection;

        private Camera mainCamera;

        private float offscreenExtent = 15;

        private void Update()
        {
            transform.position = transform.position + ((Vector3)movementDirection * movementSpeed * Time.deltaTime);
        }

        public void ActivateBullet()
        {
            movementDirection = GetRandomDirection();
            movementSpeed = GetRandomSpeed();
        }

        private Vector2 GetRandomDirection()
        {
            float randomModifier = Random.value;

            float width = Screen.width;
            float height = Screen.height;

            switch (Random.Range(0, 4))
            {
                // From bottom
                case 0:
                    transform.position = (Vector2)mainCamera.ScreenToWorldPoint(new Vector2(width * randomModifier, 0 - offscreenExtent));
                    return Vector2.up;
                // From right
                case 1:
                    transform.position = (Vector2)mainCamera.ScreenToWorldPoint(new Vector2(width + offscreenExtent, height * randomModifier));
                    return Vector2.left;
                // From left
                case 2:
                    transform.position = (Vector2)mainCamera.ScreenToWorldPoint(new Vector2(0 - offscreenExtent, height * randomModifier));
                    return Vector2.right;
                // From top
                default:
                    transform.position = (Vector2)mainCamera.ScreenToWorldPoint(new Vector2(width * randomModifier, height + offscreenExtent));
                    return Vector2.down;
            }
        }

        private float GetRandomSpeed()
        {
            return Random.Range(5.0f, 10.0f);
        }

        private void DeactivateBullet()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            ActivateBullet();
        }

        private void OnBecameInvisible()
        {
            DeactivateBullet();
        }
    }
}
