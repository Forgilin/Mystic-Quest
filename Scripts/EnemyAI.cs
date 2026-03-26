using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public EnemyTrigger enemyTrigger;

    




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        EnemyTrigger.enemyActive = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        //When enemy is active it will look at player and will go to his position
        if(EnemyTrigger.enemyActive)
        {
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }
        
        else
        {
            transform.LookAt(player);
        }

        
    }

    //If enemy catches the player, level will be restarted by loading the scene again
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
