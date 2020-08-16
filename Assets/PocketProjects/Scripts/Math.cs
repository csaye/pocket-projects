using UnityEngine;

namespace PocketProjects
{
    public class Math
    {
        public static bool Contains(BoundsInt bounds, Vector3Int position)
        {
            return bounds.min.x <= position.x && bounds.min.y <= position.y && bounds.max.x > position.x && bounds.max.y > position.y;
        }
    }
}
