using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PocketProjects.BulletHell
{
    [RequireComponent(typeof(Tilemap))]
    public class FloorGenerator : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private Vector2Int floorSize = new Vector2Int();
        [SerializeField] private Vector2Int baseSize = new Vector2Int();

        [Header("References")]
        [SerializeField] private RuleTile floorTile = null;

        private Tilemap tilemap;

        private BoundsInt floorBounds;
        private BoundsInt baseBounds;

        private void Start()
        {
            tilemap = GetComponent<Tilemap>();

            // Get floor and base bounds
            Vector3Int floorOrigin = new Vector3Int(-floorSize.x / 2, -floorSize.y / 2, 0);
            Vector3Int baseOrigin = new Vector3Int(-baseSize.x / 2, -baseSize.y / 2, 0);

            Vector3Int floorBoundsSize = new Vector3Int(floorSize.x, floorSize.y, 1);
            Vector3Int baseBoundsSize = new Vector3Int(baseSize.x, baseSize.y, 1);

            floorBounds = new BoundsInt(floorOrigin, floorBoundsSize);
            baseBounds = new BoundsInt(baseOrigin, baseBoundsSize);

            GenerateFloor();
        }

        private void GenerateFloor()
        {
            List<Vector3Int> tilePositions = new List<Vector3Int>();

            // Generate floor
            foreach (Vector3Int position in floorBounds.allPositionsWithin)
            {
                // If part of base
                if (baseBounds.Contains(position))
                {
                    tilePositions.Add(position);
                    continue;
                }
            }

            CreateTiles(tilePositions);
        }

        private void CreateTiles(List<Vector3Int> tilePositions)
        {
            foreach (Vector3Int position in tilePositions)
            {
                tilemap.SetTile(position, floorTile);
            }
        }
    }
}
