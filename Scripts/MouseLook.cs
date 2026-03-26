using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity;

    public Transform playerBody;

    float xRotation = 0f;

    public GameObject player;
    public Player playerScript;
    public ItemPickUp itemPickUpScript;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        itemPickUpScript = player.GetComponent<ItemPickUp>();
        sensitivity = playerScript.sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        if(!PauseMenu.paused && !playerScript.newGame && !playerScript.gameFinished && !playerScript.difficultySelection && !itemPickUpScript.isRotating)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
