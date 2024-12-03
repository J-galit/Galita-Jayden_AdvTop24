
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public class Cell
    {
        public bool visited = false;
        public bool[] status =new bool[4];
        public bool hasExit = false;
    }

    [System.Serializable]
    public class Rule
    {
        public GameObject room;
        public Vector2Int minPosition;
        public Vector2Int maxPosition;

        public bool obligatory;

        public int ProbabilityOfSpawing(int x, int y)
        {
            // 0 - Cannot spawn 1 - can spawn 2- HAS to spawn
            //Checks if the position is within the set range
            if (x>= minPosition.x && x<= maxPosition.x && y >= minPosition.y && y <= maxPosition.y)
            {
                return obligatory ? 2 : 1;
            }

            return 0;
        }
    }

    [SerializeField]
    private Vector2Int _size = new Vector2Int(1, 1);
    public Vector2Int size
    {
        get => _size;
        set => _size = value != Vector2Int.zero ? value : throw new System.ArgumentException("Size cannot be zero.");
    }
    
    public int startPos = 0;

    public Rule[] rooms;
    public Vector2 offset;

    List<Cell> board;


    
    void Start()
    {
        MazeGenerator();
    }



    
   void GenerateDungeon() //Creates the physical dungeon, placing the rooms.
   {

        for (int i = 0; i < size.x; i++) 
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[(i + j * size.x)];
                if (currentCell.visited) 
                {
                 //Decides what room to spawn
                    int randomRoom = -1;
                    List<int> availableRooms = new List<int>();

                    for (int k = 0; k < rooms.Length; k++)
                    {
                        //checks if it can spawn in that area return 2 or 1
                        int p = rooms[k].ProbabilityOfSpawing(i,j);

                        if(p == 2)
                        {
                            randomRoom = k;
                            break;
                        } 
                        else if(p == 1)
                        {
                            availableRooms.Add(k);
                        }
                    }
                    //Happens if it didn't spawn a obligatory room.
                    if(randomRoom == -1) 
                    {
                        if(availableRooms.Count > 0)
                        {
                            randomRoom = availableRooms[Random.Range(0,availableRooms.Count)];
                        }
                        else
                        {
                            randomRoom = 0;
                        }
                    }

                    var newRoom = Instantiate(rooms[randomRoom].room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                    newRoom.UpdateRoom(board[(i + j * size.x)].status, board[(i + j * size.x)].hasExit);
                }
                
            }

        }


   }


    void MazeGenerator() //Creates the map of the dungeon.
    {
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }

        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int k = 0;

        while(k < 1000)
        {
            k++;
            
            board[currentCell].visited = true;

            if (currentCell == board.Count - 1)
            {
                print("done");
                board[currentCell].hasExit = true;
                break;

            }

            List<int> neighbors = CheckNeighbors(currentCell);

            if (neighbors.Count == 0) 
            { 
                if(path.Count == 0)
                {
                    
                    break;
                }
                else
                {
                    currentCell = path.Pop();

                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if(newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell) 
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }
            }
        }

        GenerateDungeon();       

    }

    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check up neighbor
        if (cell - size.x >= 0 && !board[(cell - size.x)].visited)
        {
            neighbors.Add((cell - size.x));
        }

        //check down neighbor
        if (cell + size.x < board.Count && !board[(cell + size.x)].visited)
        {
            neighbors.Add((cell + size.x));
        }

        //check right neighbor
        if ((cell + 1) % size.x != 0 && !board[(cell + 1)].visited)
        {
            neighbors.Add((cell + 1));
        }

        //check left neighbor
        if (cell % size.x != 0 && !board[(cell - 1)].visited)
        {
            neighbors.Add((cell - 1));
        }

        return neighbors;
    }

}
