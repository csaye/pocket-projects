using UnityEngine;

namespace PocketProjects.BulletHell
{
    public class BulletSpawner : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private int bulletPoolSize = 0;
        [SerializeField] private float bulletSpawnTime = 0;

        [Header("References")]
        [SerializeField] private GameObject[] bulletPrefabs = new GameObject[6];

        private GameObject[] bullets = new GameObject[16];

        private float lastSpawnTime;

        private void Start()
        {
            InstantiateBullets();
        }

        private void InstantiateBullets()
        {
            for (int i = 0; i < bulletPoolSize; i++)
            {
                bullets[i] = Instantiate(RandomBullet(), Vector2.zero, Quaternion.identity, transform);
                bullets[i].SetActive(false);
            }
        }

        private GameObject RandomBullet()
        {
            return bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];
        }

        private void Update()
        {
            if (Time.time - lastSpawnTime > bulletSpawnTime)
            {
                lastSpawnTime = Time.time;
                SpawnBullet();
            }
        }

        private void SpawnBullet()
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                // If bullet not active
                if (!bullets[i].activeSelf)
                {
                    InitializeBullet(i);
                    return;
                }
            }

            Debug.LogError("Bullet call exceeds pool capacity.");
        }

        private void InitializeBullet(int index)
        {
            bullets[index].SetActive(true);
        }

        private Vector2 RandomPosition()
        {
            return Vector2.zero;
        }
    }
}
