using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PokemonDisplay : MonoBehaviour
{
    public PokemonScritptable pokemon;

    public Image pokemonImage;

    public TMP_Text nameText;
    public TMP_Text genderText;
    public TMP_Text typeText;
    public TMP_Text abilityText;
    public TMP_Text natureText;

    public string[] nature = { "Quiet", "Quirky", "Bold", "Modest", "Sassy" };
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = pokemon.name;

        genderText.text = pokemon.gender[Random.Range(0,1)];

        abilityText.text = pokemon.ability[Random.Range(0, 1)];

        typeText.text = $"{pokemon.type[0]}/{pokemon.type[1]}";

        
        natureText.text = nature[Random.Range(0, 5)];
       

        pokemonImage.sprite = pokemon.artwork;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
