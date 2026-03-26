using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL4Trigger : MonoBehaviour
{

    [SerializeField] private int triggerNumber = 1;

    public static bool codeA = false;
    public static bool codeB = false;
    public static bool codeC = false;
    public static bool codeD = false;



    


    private void OnTriggerEnter(Collider other)
    {
        switch(triggerNumber)
        {
            case 1:
                if (other.CompareTag("KeyA"))
                {
                    codeA = true;
                    Debug.Log("A");
                }
                break;
            case 2:
                if (other.CompareTag("KeyB"))
                {
                    codeB = true;
                    Debug.Log("B");
                }
                break;
            case 3:
                if (other.CompareTag("KeyC"))
                {
                    codeC = true;
                    Debug.Log("C");
                }
                break;
            case 4:
                if (other.CompareTag("KeyD"))
                {
                    codeD = true;
                    Debug.Log("D");
                }
                break;
        }

    }

    //if you take that object out, door will close
    private void OnTriggerExit(Collider other)
    {
        switch(triggerNumber)
        {
            case 1:
                if (other.CompareTag("KeyA"))
                {
                    codeA = false;
                }
                break;
            case 2:
                if (other.CompareTag("KeyB"))
                {
                    codeB = false;
                }
                break;
            case 3:
                if (other.CompareTag("KeyC"))
                {
                    codeC = false;
                }
                break;
            case 4:
                if (other.CompareTag("KeyD"))
                {
                    codeD = false;
                }
                break;
        }
    }



}
