using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : MonoBehaviour
{
    Grid grid;
    Tilemap groundTile, wallTile, objectsTile;
    List<GridObejct> gridObjects = new List<GridObejct>();

    public bool hasObject(int x, int y)
    {
        foreach (var obj in gridObjects)
        {
            if (obj.x == x && obj.y == y)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsValidPosition(int x, int y)
    {
        // Check if the position is within the bounds of the world
        if (wallTile.HasTile(new Vector3Int(x, y, 0)))
        {
            return false;
        }
        if (hasObject(x, y))
        {
            return false;
        }

        return true;
    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        // Convert grid coordinates to world coordinates
        return grid.CellToLocal(new Vector3Int(x, y, 0)) + grid.cellSize / 2;
    }
    void GetAllGridObjects()
    {
        // Get all grid objects in the world
        for (int i = 0; i < objectsTile.transform.childCount; i++)
        {
            gridObjects.Add(objectsTile.transform.GetChild(i).GetComponent<GridObejct>());
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GetComponent<Grid>();
        groundTile = transform.Find("Ground").GetComponent<Tilemap>();
        wallTile = transform.Find("Wall").GetComponent<Tilemap>();
        objectsTile = transform.Find("Objects").GetComponent<Tilemap>();
        GetAllGridObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
