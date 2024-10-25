using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject visualObject;

    private enum State
    {
        on, off
    }

    private State currentState = State.off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(currentState)
            {
                case State.on:
                    TurnOff();
                    break;

                case State.off:
                    TurnOn();
                    break;
            }
        }
    }

    public void TurnOn()
    {
        if(currentState == State.off)
        {
            visualObject.SetActive(true);
        }
        
    }

    public void TurnOff()
    {
        if(currentState == State.on)
        {
            visualObject.SetActive(false);
        }
        
    }
}
