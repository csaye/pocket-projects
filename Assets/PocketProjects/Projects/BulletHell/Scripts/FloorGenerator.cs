using UnityEngine;
using UnityEngine.Tilemaps;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(Tilemap))]
    public class FloorGenerator : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private Vector2Int baseSize = new Vector2Int();
        // [SerializeField] private Vector2Int floorSize = new Vector2Int();

        [Header("References")]
        [SerializeField] private RuleTile floorTile = null;

        private Tilemap tilemap;

        private void Start()
        {
            tilemap = GetComponent<Tilemap>();

            GenerateFloor();
        }

        private void GenerateFloor()
        {
            // Generate base
            for (int x = -baseSize.x / 2; x < baseSize.x / 2; x++)
            {
                for (int y = -baseSize.y / 2; y < baseSize.y / 2; y++)
                {
                    Vector3Int position = new Vector3Int(x, y, 0);

                    tilemap.SetTile(position, floorTile);
                }
            }
        }
    }
}
