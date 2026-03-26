using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl4OpenDoor : MonoBehaviour
{
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private MeshRenderer block;

    [SerializeField] private Transform door;

    private bool animating = false;

    private Vector3 closed = new Vector3(28.72458f,0f,43.125f);
    private Vector3 opened = new Vector3(28.72458f,-4.77f,43.125f);

    
    [SerializeField] private Light triggerLight;


    private float animTimer = 0;

    //Sounds
    [SerializeField] private AudioSource doorSound;

    void Start()
    {
        LVL4Trigger.codeA = false;
        LVL4Trigger.codeB = false;
        LVL4Trigger.codeC = false;
        LVL4Trigger.codeD = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(LVL4Trigger.codeA && LVL4Trigger.codeB && LVL4Trigger.codeC && LVL4Trigger.codeD)
        {
            block.material = green;
            animating = true;
            triggerLight.color = Color.green;
            doorSound.enabled = true;
        }
        else{
            block.material = red;
            animating = false;
            triggerLight.color = Color.red;
            doorSound.enabled = false;
        }

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
    }
}
