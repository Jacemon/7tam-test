using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMap : MonoBehaviour
{
    public Grid grid;
    public List<GameObject> objects = new();
    
    private readonly Dictionary<Vector3Int, GameObject> _occupiedCells = new();

    private void Start()
    {
        UpdateMap();
    }

    public void AddObjectToCell(Vector3Int cellPosition, GameObject obj)
    {
        _occupiedCells.TryAdd(cellPosition, obj);
    }
    
    public void RemoveObjectFromCell(Vector3Int cellPosition)
    {
        _occupiedCells.Remove(cellPosition);
    }
    
    public bool IsCellOccupied(Vector3Int cellPosition)
    {
        return _occupiedCells.ContainsKey(cellPosition);
    }
    
    public GameObject GetObjectAtCell(Vector3Int cellPosition)
    {
        return _occupiedCells.TryGetValue(cellPosition, out var obj) ? obj : null;
    }

    public void UpdateMap()
    {
        _occupiedCells.Clear();
        foreach (var obj in objects)
        { 
            AddObjectToCell(grid.WorldToCell(obj.transform.position), obj);
        }
    }
}