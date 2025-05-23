using UnityEngine;

[ExecuteInEditMode]
public class AutoSnapToGrid : MonoBehaviour
{
    World world;
    GridObject gridObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        gridObject = GetComponent<GridObject>();
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Application.isPlaying)
        {
            this.enabled = false;
        }
        Vector3Int CellPosition = world.WorldToCellPosition(transform.position);
        transform.position = world.CellToWorldPosition(CellPosition.x, CellPosition.y);
        
        if (gridObject != null)
        {
            gridObject.x = CellPosition.x;
            gridObject.y = CellPosition.y;
        }
    }

}


