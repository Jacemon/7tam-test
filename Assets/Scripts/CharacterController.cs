using System.Collections.Generic;
using Tiles;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 _targetPosition;
    public Grid grid;
    public Tilemap tilemap;
    public CollisionMap collisionMap;

    private void Start()
    {
        _targetPosition = GetPositionByCell(grid.WorldToCell(transform.position));
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
        {
            Vector3Int currentCell = grid.WorldToCell(transform.position);
            Vector3Int nextCell = currentCell;

            if (Input.GetKeyDown(KeyCode.W))
            {
                nextCell += new Vector3Int(0, 1, 0);
                Debug.Log($"{name} - Up");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                nextCell += new Vector3Int(0, -1, 0);
                Debug.Log($"{name} - Down");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                nextCell += new Vector3Int(-1, 0, 0);
                Debug.Log($"{name} - Left");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                nextCell += new Vector3Int(1, 0, 0);
                Debug.Log($"{name} - Right");
            }
            
            TileBase tile = tilemap.GetTile(nextCell);
            
            if (tile is WalkableTile { isWalkable: true } && !collisionMap.IsCellOccupied(nextCell))
            {
                _targetPosition = GetPositionByCell(nextCell);
                collisionMap.UpdateMap();
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
    }

    private Vector3 GetPositionByCell(Vector3Int cell)
    {
        Vector3 cellCenter = grid.CellToWorld(cell);
        Vector3 cellSize = grid.cellSize;

        Vector3 scale = grid.transform.localScale;
        cellCenter += new Vector3(cellSize.x * scale.x / 2, cellSize.y * scale.y / 2, 0);

        return cellCenter;
    }
}