using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    private bool enemyInRange;
    [SerializeField] private float sight;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private AudioSource heartBeatSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckSphere(transform.position, sight, enemyLayer) && !PauseMenu.paused)
        {
            heartBeatSound.enabled = true;
            if(Physics.CheckSphere(transform.position, sight/2, enemyLayer) && !PauseMenu.paused)
            {
                heartBeatSound.pitch = 1.5f;
            }
            else
            {
                heartBeatSound.pitch = 1f;
            }
        }
        else
        {
            heartBeatSound.enabled = false;
        }

    }
}
