using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool ecounter = false;

    public PokemonDisplay display;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && !ecounter)
        {
            //Encounter Rate for the Pokemon, if true creates and displays a Pokemon.
            if (Random.Range(0, 100) < 25)
            {
                display.ChooseAPokemon();
                ecounter = true;
            }
        }

        //Removes the Pokemon Display from the screen.
        if (Input.GetKeyDown("backspace"))
        {
            display.gameObject.SetActive(false);
            ecounter = false;
        }

    }
}
