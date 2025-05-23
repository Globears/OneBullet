using UnityEngine;

[ExecuteInEditMode]
public class AutosortingOrder : MonoBehaviour
{
    //TODO: different objects have different sorting way, x10, +1 etc. use the object type to determine
    World world;
    GridObject gridObject;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector3Int CellPosition = world.WorldToCellPosition(transform.position);
        spriteRenderer.sortingOrder = -CellPosition.y;
    }
}
