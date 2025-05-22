using UnityEngine;

public class TestEnemyAI_1 : GridObject
{
    World world;
    PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        world = World.instance;
        player = PlayerController.instance;
        player.MovingStart += OnPlayerMovingStart;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move(int dx, int dy)
    {
        int newX = x + dx;
        int newY = y + dy;
        x = newX;
        y = newY;
        transform.position = world.CellToWorldPosition(x, y);
    }

    void OnPlayerMovingStart(int fromX, int fromY, int newX, int newY)
    {
        Debug.Log("Player Moved!");
        Move(Random.Range(-1, 2), Random.Range(-1, 2));
    }
}
