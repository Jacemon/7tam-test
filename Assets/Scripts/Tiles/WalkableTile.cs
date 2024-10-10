namespace Tiles
{
    using UnityEngine;
    using UnityEngine.Tilemaps;

    [CreateAssetMenu(fileName = "New Walkable Tile", menuName = "Tiles/WalkableTile")]
    public class WalkableTile : Tile
    {
        public bool isWalkable;
    }

}