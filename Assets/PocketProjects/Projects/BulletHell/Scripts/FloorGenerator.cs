using UnityEngine;
using UnityEngine.Tilemaps;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(Tilemap))]
    public class FloorGenerator : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private Vector2Int floorSize = new Vector2Int();

        private Tilemap tilemap;

        private void Start()
        {
            tilemap = GetComponent<Tilemap>();

            GenerateFloor();
        }

        private void GenerateFloor()
        {
            Debug.Log(floorSize);
        }
    }
}
