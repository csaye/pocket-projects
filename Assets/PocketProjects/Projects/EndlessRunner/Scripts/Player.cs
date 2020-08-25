using UnityEngine;

namespace PocketProjects.EndlessRunner
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float moveForce = 0;
        [SerializeField] private float jumpForce = 0;

        private Rigidbody2D rb;

        private Vector2 jump;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            jump = new Vector2(0, jumpForce);
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");

            Vector2 direction = new Vector2(x, 0);

            rb.AddForce(direction * moveForce * Time.deltaTime);
        }

        private void Jump()
        {
            if (Input.GetButtonDown("Jump") && Grounded())
            {
                rb.AddForce(jump);
            }
        }

        private bool Grounded()
        {
            return Mathf.Abs(rb.velocity.y) < 0.01f;
        }
    }
}
