using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : MonoBehaviour
{
    public Grid grid;
    Tilemap groundTile, wallTile, objectsTile;
    List<GridObject> gridObjects = new List<GridObject>();

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

    public bool hasWall(int x, int y)
    {
        return wallTile.HasTile(new Vector3Int(x, y, 0));
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
    void RegisterAllGridObjects()
    {
        // Get all grid objects in the world
        for (int i = 0; i < objectsTile.transform.childCount; i++)
        {
            gridObjects.Add(objectsTile.transform.GetChild(i).GetComponent<GridObject>());
        }
    }
    public GridObjectType GetGridAt(int x, int y)
    {
        if (wallTile.HasTile(new Vector3Int(x, y, 0)))
        {
            return GridObjectType.Wall;
        }
        foreach (var obj in gridObjects)
        {
            if (obj.x == x && obj.y == y)
            {
                return obj.GetComponent<GridObject>().type;
            }
        }
        return GridObjectType.None;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        grid = GetComponent<Grid>();
        groundTile = transform.Find("Ground").GetComponent<Tilemap>();
        wallTile = transform.Find("Wall").GetComponent<Tilemap>();
        objectsTile = transform.Find("Objects").GetComponent<Tilemap>();
        RegisterAllGridObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
