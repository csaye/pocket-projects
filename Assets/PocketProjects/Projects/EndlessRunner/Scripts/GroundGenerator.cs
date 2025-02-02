﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PocketProjects.EndlessRunner
{
    public class GroundGenerator : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private int lowerY = 0;
        [SerializeField] private float groundRoughness = 0;
        [SerializeField] private float groundHeight = 0;

        [Header("References")]
        [SerializeField] private Camera mainCamera = null;
        [SerializeField] private Tilemap groundTilemap = null;
        [SerializeField] private RuleTile groundTile = null;

        private int seed;

        private List<int> groundSlices = new List<int>();

        private Vector2 minScreenPoint;
        private Vector2 maxScreenPoint;

        private void Start()
        {
            seed = GetRandomSeed();

            minScreenPoint = Vector2.zero;
            maxScreenPoint = new Vector2(Screen.width, Screen.height);

            InitializeGround();
        }

        private int GetRandomSeed()
        {
            return Random.Range(int.MinValue, int.MaxValue) % 1000000;
        }

        private void InitializeGround()
        {
            Vector2 minExtent = mainCamera.ScreenToWorldPoint(minScreenPoint);
            Vector2 maxExtent = mainCamera.ScreenToWorldPoint(maxScreenPoint);

            int minX = Mathf.FloorToInt(minExtent.x);
            int maxX = Mathf.CeilToInt(maxExtent.x);

            for (int x = minX; x < maxX + 3; x++)
            {
                GenerateSlice(x);
            }
        }

        private void Update()
        {
            CheckGround();
        }

        private void CheckGround()
        {
            Vector2 minExtent = mainCamera.ScreenToWorldPoint(minScreenPoint);

            int minX = Mathf.FloorToInt(minExtent.x);

            // If screen scrolled past furthest slice
            if (groundSlices[0] < minX - 1)
            {
                RemoveSlice(groundSlices[0]);
                GenerateSlice(groundSlices[groundSlices.Count - 1] + 1);
            }
        }

        private void GenerateSlice(int x)
        {
            groundSlices.Add(x);

            float upperYFloat = Mathf.PerlinNoise((x + seed) * groundRoughness, seed * groundRoughness) * groundHeight;
            int upperY = Mathf.CeilToInt(upperYFloat);

            for (int y = lowerY; y < upperY; y++)
            {
                GenerateTile(new Vector2Int(x, y));
            }
        }

        private void RemoveSlice(int x)
        {
            groundSlices.Remove(x);

            Vector3Int pos = new Vector3Int(x, lowerY, 0);

            // Remove all tiles in slice
            while (groundTilemap.GetTile(pos) != null)
            {
                groundTilemap.SetTile(pos, null);
                pos += Vector3Int.up;
            }
        }

        private void GenerateTile(Vector2Int pos)
        {
            groundTilemap.SetTile((Vector3Int)pos, groundTile);
        }
    }
}
