using ChickenScratch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SpriteRenderer speakerARenderer, speakerBRenderer;

    [SerializeField]
    private Color offColour, onColour;

    [SerializeField]
    private float totalOnTime;

    private float currentTimeOn = 0f;

    [SerializeField]
    private string onSoundName;

    private enum State
    {
        on, off
    }
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.on:
                currentTimeOn += Time.deltaTime;
                if(currentTimeOn > totalOnTime)
                {
                    currentState = State.off;
                    AudioManager.Instance.StopSound(onSoundName);
                    currentTimeOn = 0f;
                    speakerARenderer.color = offColour;
                    speakerBRenderer.color = offColour;
                }
                else
                {
                    float ratio = currentTimeOn / totalOnTime;
                    speakerARenderer.color = Color.Lerp(onColour, offColour, ratio);
                    speakerBRenderer.color = Color.Lerp(onColour, offColour, ratio);
                }
                break;
        }
    }

    public void Interact()
    {
        if(currentState == State.off)
        {
            currentTimeOn = 0f;
            currentState = State.on;
            speakerARenderer.color = onColour;
            speakerBRenderer.color = onColour;
            AudioManager.Instance.PlaySound(onSoundName);
        }
    }
}
