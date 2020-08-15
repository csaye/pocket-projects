using UnityEngine;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float moveSpeed = 0;

        private Rigidbody2D rb;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            rb.velocity = MoveDirection() * moveSpeed;
        }

        private Vector2 MoveDirection()
        {
            Vector2 direction = Vector2.zero;

            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
            
            direction = direction.normalized;

            return direction;
        }
    }
}
