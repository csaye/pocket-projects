using UnityEngine;

namespace PocketProjects.EndlessRunner
{
    public class SidescrollCamera : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float scrollSpeedMin = 0;
        [SerializeField] private float scrollSpeedMax = 0;
        [SerializeField] private float speedIncreaseRate = 0;

        [SerializeField] private float scrollSpeed;

        private float yPos;
        private float zPos;

        private void Start()
        {
            scrollSpeed = scrollSpeedMin;

            yPos = transform.position.y;
            zPos = transform.position.z;
        }

        private void Update()
        {
            Scroll(scrollSpeed * Time.deltaTime);
        }

        private void Scroll(float scrollDistance)
        {
            transform.position = new Vector3(transform.position.x + scrollDistance, yPos, zPos);

            if (scrollSpeed < scrollSpeedMax)
            {
                scrollSpeed += speedIncreaseRate * Time.deltaTime;
            }
        }
    }
}
