using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CyclesManager : MonoBehaviour
{
    [SerializeField]
    private float dayLength, nightLength;

    [SerializeField]
    private GameObject dayBGObject, nightBGObject;

    public enum Cycle
    {
        day, night
    }

    public Cycle CurrentCycle => currentCycle;
    private Cycle currentCycle = Cycle.day;

    private float timeInCycle = 0f;

    void Update()
    {
        timeInCycle += Time.deltaTime;
        switch(currentCycle)
        {
            case Cycle.day:
                if(timeInCycle > dayLength)
                {
                    timeInCycle = 0f;
                    currentCycle = Cycle.night;
                    dayBGObject.SetActive(false);
                    nightBGObject.SetActive(true);
                }
                break;
            case Cycle.night:
                if(timeInCycle > nightLength)
                {
                    timeInCycle = 0f;
                    currentCycle = Cycle.day;
                    dayBGObject.SetActive(true);
                    nightBGObject.SetActive(false);
                }

                break;
        }
    }
}

