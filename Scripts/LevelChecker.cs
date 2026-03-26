using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChecker : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;

    [SerializeField] private GameObject doorTrigger2;
    [SerializeField] private GameObject doorBlock2;

    [SerializeField] private GameObject doorTrigger3;
    [SerializeField] private GameObject doorBlock3;

    [SerializeField] private GameObject doorTrigger4;
    [SerializeField] private GameObject doorBlock4;

    [SerializeField] private GameObject doorTrigger5;
    [SerializeField] private GameObject doorBlock5;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject welcomeScreen;

    private GameObject HUD;

    //sounds
    [SerializeField] private AudioSource WinSource;
    [SerializeField] private AudioClip WinSound;
    




    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        HUD = GameObject.Find("HUD");
    }

    void Start()
    {
        if(playerScript.lvl2Acces)
        {
            doorTrigger2.SetActive(true);
            doorBlock2.SetActive(false);
        }

        if(playerScript.lvl3Acces)
        {
            doorTrigger3.SetActive(true);
            doorBlock3.SetActive(false);
        }

        if(playerScript.lvl4Acces)
        {
            doorTrigger4.SetActive(true);
            doorBlock4.SetActive(false);
        }

        if(playerScript.lvl5Acces)
        {
            doorTrigger5.SetActive(true);
            doorBlock5.SetActive(false);
        }

        if(playerScript.newGame)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            HUD.SetActive(false);

        }
        else
        {
            IntroEnd();
        }

        if(playerScript.gameFinished)
        {
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            HUD.SetActive(false);
            WinSource.PlayOneShot(WinSound);
        }
    }


    public void IntroEnd()
    {
        welcomeScreen.SetActive(false);
        Time.timeScale = 1;
        playerScript.newGame = false;
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
    }

}
