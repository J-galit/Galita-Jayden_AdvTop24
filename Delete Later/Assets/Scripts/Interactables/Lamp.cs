using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SpriteRenderer lampVisual;

    [SerializeField]
    private Color onColour, offColour;

    [SerializeField]
    private float stateChangeCooldown;

    private float timeSinceLastChange;

    public bool canBeChanged => timeSinceLastChange >= stateChangeCooldown;

    private enum State
    {
        on, off
    }
    private State currentState = State.off;

    private void Start()
    {
        timeSinceLastChange = stateChangeCooldown;
    }

    private void Update()
    {
        if(timeSinceLastChange <= stateChangeCooldown)
        {
            timeSinceLastChange += Time.deltaTime;
        }
        
    }

    public void Interact()
    {
        if(canBeChanged)
        {
            switch(currentState)
            {
                case State.on:
                    lampVisual.color = offColour;
                    currentState = State.off;
                    break;
                case State.off:
                    lampVisual.color = onColour;
                    currentState = State.on;
                    break;
            }
            timeSinceLastChange = 0f;
        }
    }
}
