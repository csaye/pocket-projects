using UnityEngine;
using UnityEngine.SceneManagement;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float moveSpeed = 0;

        private Rigidbody2D rb;
        private Animator animator;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
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

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            
            direction = direction.normalized;

            return direction;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            // If collided with bullet
            if (collider.gameObject.GetComponent<Bullet>() != null)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            SceneManager.LoadScene("BulletHellGameOver");
        }
    }
}
