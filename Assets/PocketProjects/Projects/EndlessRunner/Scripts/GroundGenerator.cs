using UnityEngine;
using UnityEngine.Tilemaps;

namespace PocketProjects.EndlessRunner
{
    public class GroundGenerator : MonoBehaviour
    {
        // [Header("Attributes")]
        // [SerializeField] private float;

        [Header("References")]
        [SerializeField] private Camera mainCamera = null;
        [SerializeField] private Tilemap groundTilemap = null;
        [SerializeField] private RuleTile groundTile = null;

        private int seed;

        private List<int> groundSlices = new List<int>();

        private void Start()
        {
            seed = GetRandomSeed();

            InitializeGround();
        }

        private void InitializeGround()
        {
            Vector2 minExtent = mainCamera.ScreenToWorldPoint(Vector2.zero);
            Vector2 maxExtent = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            int minX = Mathf.FloorToInt(minExtent.x);

            for ()
        }

        private void Update()
        {
            Vector2 minExtent = mainCamera.ScreenToWorldPoint(Vector2.zero);
            Vector2 maxExtent = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        }

        private int GetRandomSeed()
        {
            return Random.Range(int.MinValue, int.MaxValue) % 1000000;
        }

        private void CreateTile()
        {
            groundTilemap.SetTile();
        }
    }
}
