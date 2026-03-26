using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl5EnemySounds : MonoBehaviour
{
    private AudioSource footsteps;
    // Start is called before the first frame update
    void Start()
    {
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.paused)
        {
            footsteps.enabled = false;
        }
        else
        {
            footsteps.enabled = true;
        }
    }
}
