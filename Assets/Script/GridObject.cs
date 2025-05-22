using UnityEngine;


public enum GridObjectType
{
    Player,
    Wall,
    Ground,
    Plate,
    Enemy,
    Deflector,
    None,
}

public class GridObject : MonoBehaviour
{
    public GridObjectType type;
    public World world;
    public int x, y;

    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();

    }

    


}

