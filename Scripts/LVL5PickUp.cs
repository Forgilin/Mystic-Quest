using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LVL5PickUp : MonoBehaviour
{
    //Layers that are able to be picked up
    [SerializeField] private LayerMask PickUpMask;
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private float PickUpRange;

    [SerializeField] private AudioSource pickUpSource;
    [SerializeField] private AudioClip pickUpSound;

    [SerializeField] private GameObject keyGetText;
    [SerializeField] private TMP_Text keygetTextText;

    public static bool keyPickedUp;

    private GameObject key;




    // Start is called before the first frame update
    void Start()
    {
        keyPickedUp = false;
        key = GameObject.Find("Key");
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = PlayerCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        if(Physics.Raycast(ray, out RaycastHit hit, PickUpRange, PickUpMask) && Input.GetKeyDown(KeyCode.E))
        {
            keyPickedUp = true;
            pickUpSource.PlayOneShot(pickUpSound);
            keygetTextText.text = "Super, klíč už mám";
            keyGetText.SetActive(true);
            Destroy(key);
            StartCoroutine(Timer());
        }



    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        keygetTextText.text = "teď se jen vrátit ke dveřím";
        yield return new WaitForSeconds(3f);
        keyGetText.SetActive(false);
    }
}
