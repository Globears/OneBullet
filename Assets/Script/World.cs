using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : MonoBehaviour
{
    public static World instance;
    public Grid grid;
    Tilemap tilemap;
    List<GridObject> gridObjects = new List<GridObject>();
    static GridObject air;

    

    void RegisterAllGridObjects()
    {
        for (int i = 0; i < tilemap.transform.childCount; i++)
        {
            GridObject gridObject = tilemap.transform.GetChild(i).GetComponent<GridObject>();
            gridObjects.Add(gridObject);
        }
    }

    public Vector3 CellToWorldPosition(int x, int y)
    {
        Vector3Int cellPosition = new Vector3Int(x, y, 0);
        return grid.GetCellCenterWorld(cellPosition);
    }

    public Vector3Int WorldToCellPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = grid.WorldToCell(worldPosition);
        return cellPosition;
    }

    public GridObject GetGridObjectAt(int x, int y)
    {
        foreach (GridObject gridObject in gridObjects)
        {
            if (gridObject.x == x && gridObject.y == y)
            {
                return gridObject;
            }
        }
        return air;
    }

    void Awake()
    {
        instance = this;
        air = GetComponent<GridObject>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap = transform.Find("Tilemap").GetComponent<Tilemap>();
        RegisterAllGridObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
