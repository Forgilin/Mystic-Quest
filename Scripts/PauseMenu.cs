using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool paused = false;

    //References to parts of UI
    public GameObject pauseMenu;
    public GameObject HUD;
    public GameObject dataPersistanceManagerObject;
    public DataPersistanceManager dataPersistanceManager;

    public GameObject player;
    public Player playerScript;

    private bool settingsOpened = false;

    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject settingsObject;



    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        dataPersistanceManagerObject = GameObject.Find("DataPersistenceManager");
        dataPersistanceManager = dataPersistanceManagerObject.GetComponent<DataPersistanceManager>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //If player presses Escape game will Pause/Resume
        if(Input.GetKeyDown(KeyCode.Escape) && !playerScript.newGame && !playerScript.difficultySelection && !playerScript.gameFinished)
        {
            if(paused && !settingsOpened)
            {
                Resume();
            }
            else if (paused && settingsOpened)
            {
                SettingsClose();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //hiding Pause menu, showing back HUD, Time scale is set back to normal, Cursor is locked
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }

    void Pause()
    {
        //showing Pause menu, hiding HUD, Time scale is set to 0, Cursor is unlocked
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        paused = true;
    }

    //Restarting level by loading scene again
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Loading lobby scene
    public void BackToLobby()
    {
        dataPersistanceManager.SaveGame();
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        //string path = Path.Combine(Application.persistentDataPath, dataPersistanceManager.fileName);
        //File.Delete(path);
        //dataPersistanceManager.NewGame();

        playerScript.lvl2Acces = false;
        playerScript.lvl3Acces = false;
        playerScript.lvl4Acces = false;
        playerScript.lvl5Acces = false;
        playerScript.gameFinished = false;
        playerScript.newGame = true;


        dataPersistanceManager.SaveGame();
        SceneManager.LoadScene(0);
    }

    //Exiting the game
    public void Exit()
    {
        
        Application.Quit();
        Debug.Log("Exit");
    }

    public void SettingsOpen()
    {
        settingsOpened = true;
        pauseMenuObject.SetActive(false);
        settingsObject.SetActive(true);
    }

    public void SettingsClose()
    {
        settingsOpened = false;
        settingsObject.SetActive(false);
        pauseMenuObject.SetActive(true);
        dataPersistanceManager.SaveGame();
    }

}
