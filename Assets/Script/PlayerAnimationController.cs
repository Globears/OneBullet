using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        player = PlayerController.instance;
        EventManager.OnPlayerMovingStart += OnPlayerMovingStart;
        EventManager.OnPlayerMovingFinish += OnPlayerMovingFinish;

        animator.Play("IdleDown");
    }

    // Update is called once per frame

    void OnPlayerMovingStart(int fromX, int fromY, int newX, int newY)
    {
        int dx = newX - fromX;
        int dy = newY - fromY;
        if (dx == 0 && dy == 1)
        {
            animator.Play("StepUp");
        }
        else if (dx == 0 && dy == -1)
        {
            animator.Play("StepDown");
        }
        else if (dx == 1 && dy == 0)
        {
            animator.Play("StepRight");
        }
        else if (dx == -1 && dy == 0)
        {
            animator.Play("StepLeft");
        }
    }

    void OnPlayerMovingFinish(int fromX, int fromY, int newX, int newY)
    {
        int dx = newX - fromX;
        int dy = newY - fromY;
        if (dx == 0 && dy == 1)
        {
            animator.Play("IdleUp");
        }
        else if (dx == 0 && dy == -1)
        {
            animator.Play("IdleDown");
        }
        else if (dx == 1 && dy == 0)
        {
            animator.Play("IdleRight");
        }
        else if (dx == -1 && dy == 0)
        {
            animator.Play("IdleLeft");
        }
    }

 
}
