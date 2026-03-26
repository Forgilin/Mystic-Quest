using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{

    public ItemPickUp itemPickUp;
    //Masks
    [SerializeField] private LayerMask layerMaskInteract;

    //Bools
    bool doOnce = false;
    bool isCrosshairActive = false;

    //croshair image
    [SerializeField] private Image crosshair = null;
    [SerializeField] Sprite crosshairNormal;
    [SerializeField] Sprite crosshairActive;

    //RayCast range
    [SerializeField] private float RaycastRange;


    //Help area
    [SerializeField] private GameObject helpArea1;
    [SerializeField] TMP_Text helpText1;
    [SerializeField] TMP_Text iconLetter1;



    [SerializeField] private GameObject helpArea2;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;


        //Chechking if looking at object with layer pickUp
        if(Physics.Raycast(transform.position, transform.forward, out hit, RaycastRange, layerMaskInteract) || itemPickUp.objectPicked)
        {
            //Changing help text
            helpArea1.SetActive(true);
            if(itemPickUp.objectPicked)
            {
                helpArea2.SetActive(true);
                if(itemPickUp.isRotating)
                {
                    helpText1.text = "Držte pro otáčení";
                    helpArea2.SetActive(false);
                    iconLetter1.text="R";
                }
                else
                {
                    helpText1.text = "Položit";
                    iconLetter1.text="E";
                }
            }
            else
            {
                helpArea2.SetActive(false);
                helpText1.text = "Vzít";
            }
            
            //changing crosshair
            if(!doOnce)
            {
                CrosshairChange(true);
            }
            doOnce = true;




            
        }
        else
        {
            //hiding help area and changing crosshair back to normal
            helpArea1.SetActive(false);
            helpArea2.SetActive(false);
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }


    //Crosshair changing function
    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
        {
            crosshair.sprite = crosshairActive;
            //crosshair.color = Color.red;
            isCrosshairActive = true;
        }
        else
        {
            crosshair.sprite = crosshairNormal;
            //crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }


}
