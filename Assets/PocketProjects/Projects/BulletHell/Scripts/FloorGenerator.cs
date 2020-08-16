﻿using System.Collections.Generic;
using TMPro;
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

            // Generate base
            // foreach (Vector3Int position in baseBounds.allPositionsWithin)
            // {
            //     tilePositions.Add(position);
            // }

            // Generate floor
            foreach (Vector3Int position in floorBounds.allPositionsWithin)
            {
                float weight = GetWeight(position);

                if (Random.value < weight)
                {
                    tilePositions.Add(position);
                }
            }

            TrimTiles(tilePositions);
            CreateTiles(tilePositions);
        }

        // Get tile generation weight based on position
        private float GetWeight(Vector3Int position)
        {
            float xCloseness = (floorSize.x / 2) - Mathf.Abs(position.x);
            float yCloseness = (floorSize.y / 2) - Mathf.Abs(position.y);

            float xWeight = xCloseness / (floorSize.x / 2);
            float yWeight = yCloseness / (floorSize.y / 2);

            return (xWeight + yWeight) / 2;
        }

        private void TrimTiles(List<Vector3Int> tilePositions)
        {
            bool removeTile = false;
            bool createTile = false;

            Vector3Int changePosition = new Vector3Int();

            foreach (Vector3Int position in tilePositions)
            {
                // If position bordered by four empty spaces
                if (!tilePositions.Contains(position + Vector3Int.up)
                && !tilePositions.Contains(position + Vector3Int.left)
                && !tilePositions.Contains(position + Vector3Int.right)
                && !tilePositions.Contains(position + Vector3Int.down))
                {
                    changePosition = position;
                    removeTile = true;
                    break;
                }
            }

            // If necessary, change tilemap and re-trim

            if (removeTile)
            {
                tilemap.SetTile(changePosition, null);
                tilePositions.Remove(changePosition);
                TrimTiles(tilePositions);
            }

            if (createTile)
            {
                tilemap.SetTile(changePosition, floorTile);
                tilePositions.Add(changePosition);
                TrimTiles(tilePositions);
            }
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
