using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{

    public GameObject[] walls; // 0 - up, 1 - down, 2 - right, 3 - left
    public GameObject[] doors;
    public GameObject exit;

    

    public void UpdateRoom(bool[] status, bool exitStatus)
    {
        for (int i = 0; i < status.Length; i++) 
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
            exit.SetActive(exitStatus);
        }
    }
}
