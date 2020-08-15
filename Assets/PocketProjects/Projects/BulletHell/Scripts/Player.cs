using UnityEngine;

namespace PocketProjects.BulletHell
{
    public class Player : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float movementSpeed;
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);

            transform.position = transform.position + (Vector3)direction;
        }
    }
}
