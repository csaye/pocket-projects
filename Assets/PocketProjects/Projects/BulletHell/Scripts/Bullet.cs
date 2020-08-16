using UnityEngine;

namespace PocketProjects.BulletHell
{
    public class Bullet : MonoBehaviour
    {
        private float movementSpeed;
        private Vector2 movementDirection;

        private void Update()
        {
            transform.position = transform.position + movementDirection * movementSpeed;
        }

        public void ActivateBullet()
        {
            transform.position = GetRandomPosition();
            movementSpeed = GetRandomSpeed();
        }

        private Vector2 GetRandomPosition()
        {

            movementDirection = 
        }

        private float GetRandomSpeed()
        {
            
        }

        private void DeactivateBullet()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            ActivateBullet();
        }

        private void OnBecameInvisible()
        {
            DeactivateBullet();
        }
    }
}
