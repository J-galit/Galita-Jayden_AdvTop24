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
            if (Random.Range(0, 100) < 25)
            {
                display.ChooseAPokemon();
                ecounter = true;
            }
        }

        if (Input.GetKeyDown("backspace"))
        {
            display.gameObject.SetActive(false);
            ecounter = false;
        }

    }
}
