using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Pokemon")]
public class PokemonScritptable : ScriptableObject
{
    public new string name;

    public string[] gender = new string[2];

    public string[] type = new string[2];

    public string[] ability = new string[2];

    


    public Sprite artwork;
}
