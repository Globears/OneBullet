using UnityEngine;

public class Exit : GridObject
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.OnPlayerMovingStart += OnPlayerMovingStart;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void OnPlayerMovingStart(int fromX, int fromY, int newX, int newY)
    {
        if (newX == x && newY == y)
        {
            OnPlayerExit();
        }
        // Handle player moving start event
    }

    void OnPlayerExit()
    {
        Debug.Log("Player has exited the level!");
    }
}
