using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public static bool enemyActive = false;
    [SerializeField] private int triggerNumber;
    public static bool stunned = false;

    [SerializeField] private GameObject restartText;


    [SerializeField] private int levelNumber;

    void Awake()
    {
        stunned = false;

        if(levelNumber == 2)
        {
            restartText = GameObject.Find("RestartujHru");
        }
    }

    void Start()
    {
        if(levelNumber == 2)
        {
            restartText.SetActive(false);
        }
    }

    void Update()
    {
        if(stunned)
        {
            restartText.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(triggerNumber)
            {
                //trigger to activate enemy
                case 1:
                    enemyActive = true;
                    break;
                //trigger to deactivate enemy
                case 2:
                    enemyActive = false;
                    break;
                //trigger to stun player
                case 3:
                    stunned = true;
                    break;
            }
        }
    }


}
