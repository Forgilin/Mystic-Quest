using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool lvl2Acces;
    public bool lvl3Acces;
    public bool lvl4Acces;
    public bool lvl5Acces;
    public bool gameFinished;
    public bool newGame;
    public float sensitivity;

    //NewGame data
    public GameData()
    {
        this.lvl2Acces = false;
        this.lvl3Acces = false;
        this.lvl4Acces = false;
        this.lvl5Acces = false;
        this.gameFinished = false;
        this.newGame = true;
        this.sensitivity = 100;
    }


}
