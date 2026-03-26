using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3ShowHelp : MonoBehaviour
{

    [SerializeField] private GameObject helpText;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4f);
        helpText.SetActive(false);
    }
}
