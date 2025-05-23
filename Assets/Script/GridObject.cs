using JetBrains.Annotations;
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
    public int x, y;



}

