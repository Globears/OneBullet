using UnityEngine;

public class PlayerController : GridObejct
{

    
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1, 0);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
