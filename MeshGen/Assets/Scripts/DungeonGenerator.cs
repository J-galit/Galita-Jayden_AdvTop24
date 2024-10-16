using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public class Cell
    {
        public bool vistited = false;
        public bool[] status =new bool[4];
    }

    public Vector2 size;
    public int startPos = 0;

    List<Cell> board;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MazeGenerator()
    {

    }

    void CheckNeighbors()
    {

    }

}
