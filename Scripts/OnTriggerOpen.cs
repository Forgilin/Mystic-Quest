using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OnTriggerOpen : MonoBehaviour
{
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private MeshRenderer block;

    [SerializeField] private Transform door;

    private bool animating = false;

    private Vector3 closed;
    private Vector3 opened;

    [SerializeField] private int level = 1;

    //lvl 1
    private Vector3 closed1 = new Vector3(37.72f,0f,98.04148f);
    private Vector3 opened1 = new Vector3(37.72f,-4.77f,98.04148f);

    //lvl 2
    private Vector3 closed2 = new Vector3(77.32539f,0f,101.3468f);
    private Vector3 opened2 = new Vector3(77.32539f,-4.77f,101.3468f);

    //lvl 3
    private Vector3 closed3 = new Vector3(24.97324f,0f,241.4434f);
    private Vector3 opened3 = new Vector3(24.97324f,-4.77f,241.4434f);


    [SerializeField] private Light triggerLight;

    [SerializeField] private string colliderTag;


    //door sound
    [SerializeField] private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        switch(level)
        {
            case 1:
                closed = closed1;
                opened = opened1;
                break;
            case 2:
                closed = closed2;
                opened = opened2;
                break;
            case 3:
                closed = closed3;
                opened = opened3;
                break;
        }
    }

    private float animTimer = 0;

    // Update is called once per frame
    void Update()
    {
        

        //Door opening/closing animation
        if(animating)
        {
            animTimer = Mathf.Clamp01(animTimer + Time.deltaTime*2);
            door.position=Vector3.Lerp(closed,opened,animTimer);
        }
        else if (animTimer >0)
        {
            animTimer = Mathf.Clamp01(animTimer - Time.deltaTime*8);
            door.position=Vector3.Lerp(closed,opened,animTimer);
        }

        if(!animating)
        {
            doorSound.enabled = false;
        }
    }

    //if you put object with tag key to the trigger, doors will open
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(colliderTag))
        {
            block.material = green;
            animating = true;
            triggerLight.color = Color.green;
            doorSound.enabled = true;
        }
    }

    //if you take that object out, door will close
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(colliderTag))
        {
            block.material = red;
            animating = false;
            triggerLight.color = Color.red;
            doorSound.enabled = true;
        }
    }



}
