using UnityEngine;

public class GridObejct : MonoBehaviour
{
    public World world;
    public int x, y;
    void Awake()
    {
        world = GameObject.Find("World").GetComponent<World>();
        if (world == null)
        {
            Debug.LogError("World component not found!");
        }
    }

    public void Move(Vector3Int direction)
    {
        Move(direction.x, direction.y);
    }
    public void Move(int dx, int dy)
    {
        int newX = x + dx;
        int newY = y + dy;

        if (world.IsValidPosition(newX, newY))
        {
            x = newX;
            y = newY;
            transform.position = world.GetWorldPosition(x, y);
        }
    }
}
