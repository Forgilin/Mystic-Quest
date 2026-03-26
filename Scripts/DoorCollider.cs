using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollider : MonoBehaviour
{

    [SerializeField] private int scene;
    [SerializeField] private int level = 0;
    [SerializeField] private bool levelFinish = false;

    public GameObject player;
    public Player playerScript;

    public GameObject dataPersistanceManagerObject;
    public DataPersistanceManager dataPersistanceManager;

    [SerializeField] private GameObject loadingScreen;
    

    // Start is called before the first frame update

    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        

        dataPersistanceManagerObject = GameObject.Find("DataPersistenceManager");
        dataPersistanceManager = dataPersistanceManagerObject.GetComponent<DataPersistanceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(levelFinish)
        {
            switch(level)
            {
                case 1:
                    playerScript.lvl2Acces = true;
                    break;

                case 2:
                    playerScript.lvl3Acces = true;
                    break;

                case 3:
                    playerScript.lvl4Acces = true;
                    break;

                case 4:
                    playerScript.lvl5Acces = true;
                    break;  
            }
        }

        if (other.CompareTag("Player"))
        {
            if(level !=5)
            {
                dataPersistanceManager.SaveGame();
                loadingScreen.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+scene);
            }
            else if(level == 5 && LVL5PickUp.keyPickedUp)
            {
                playerScript.gameFinished = true;
                dataPersistanceManager.SaveGame();
                loadingScreen.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+scene);
            }
        }
    }
}
