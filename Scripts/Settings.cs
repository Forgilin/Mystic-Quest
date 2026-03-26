using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Slider = UnityEngine.UI.Slider;

public class Settings : MonoBehaviour
{

    [SerializeField] private Slider sensitivitySlider;
    
    
    public GameObject player;
    public GameObject mainCamera;
    public Player playerScript;
    public MouseLook mouseLookScript;

    public GameObject dataPersistanceManagerObject;
    public DataPersistanceManager dataPersistanceManager;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        playerScript = player.GetComponent<Player>();
        mouseLookScript = mainCamera.GetComponent<MouseLook>();
        dataPersistanceManagerObject = GameObject.Find("DataPersistenceManager");
        dataPersistanceManager = dataPersistanceManagerObject.GetComponent<DataPersistanceManager>();
        sensitivitySlider.value = playerScript.sensitivity;    
    }

    public void setSensitivity(float value)
    {
        mouseLookScript.sensitivity = value;
        playerScript.sensitivity = value;
    }

    public void Save()
    {
        dataPersistanceManager.SaveGame();
    }

}
