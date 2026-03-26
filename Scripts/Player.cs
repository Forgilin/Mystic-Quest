using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDataPersistance
{

    public bool lvl2Acces;
    public bool lvl3Acces;
    public bool lvl4Acces;
    public bool lvl5Acces;

    public bool gameFinished;
    public bool winScreenShoved;
    public bool newGame;

    public bool difficultySelection = false;

    public float sensitivity;


    public void LoadData(GameData data)
    {
        this.lvl2Acces = data.lvl2Acces;
        this.lvl3Acces = data.lvl3Acces;
        this.lvl4Acces = data.lvl4Acces;
        this.lvl5Acces = data.lvl5Acces;
        this.gameFinished = data.gameFinished;
        this.newGame = data.newGame;
        this.sensitivity = data.sensitivity;

    }

    public void SaveData(ref GameData data)
    {
        data.lvl2Acces = this.lvl2Acces;
        data.lvl3Acces = this.lvl3Acces;
        data.lvl4Acces = this.lvl4Acces;
        data.lvl5Acces = this.lvl5Acces;
        data.gameFinished = this.gameFinished;
        data.newGame = this.newGame;
        data.sensitivity = this.sensitivity;
    }
    



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //If player presses J the level will be restarted by loading the scene again
        if(Input.GetKey(KeyCode.J) && !PauseMenu.paused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
