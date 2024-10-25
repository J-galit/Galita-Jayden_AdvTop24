using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;

    private Rigidbody2D rb;

    [SerializeField] private float drunk = 0f;

    private enum Inputs
    {
        Up, Down, Left, Right
    };

    private Inputs lastInput = Inputs.Up;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(InputManager.movement.x, InputManager.movement.y);
        
        print(GetlastInput(ref lastInput));

       
       

        rb.velocity = movement * moveSpeed;

        
    }


    Inputs GetlastInput(ref Inputs lastInput)
    {

        if (InputManager.movement.y == 1f && InputManager.movement.x == 0)
        {
            lastInput = Inputs.Up;
        }
        else if (InputManager.movement.y == -1f && InputManager.movement.x == 0)
        {
            lastInput = Inputs.Down;
        }
        else if (InputManager.movement.y == 0f && InputManager.movement.x == 1f)
        {
            lastInput = Inputs.Right;
        }
        else if (InputManager.movement.y == 0f && InputManager.movement.x == -1f)
        {
            lastInput = Inputs.Left;
        }

        return lastInput;
    }
}
