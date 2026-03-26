using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    public static ItemPickUp Instance;

    //Layers that are able to be picked up
    [SerializeField] private LayerMask PickUpMask;

    //Layers for ignoring collision while rotating
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private LayerMask NothingLayer;


    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickUpTarget;
    [SerializeField] private float PickUpRange;


    //bool to lock X and Z rotation
    [SerializeField] private bool lockRotation = false;


    //Variables of object
    private Rigidbody CurrentObject;
    private Collider CurrentColider;
    private Transform ObjectTransform; 


    public bool objectPicked = false;
    public bool isRotating = false;

    //getting mouse look script
    public MouseLook mouseLook;


    


    



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        




        if(Input.GetKeyDown(KeyCode.E))
        {

            //changing settings back to normal when dropped
            if(CurrentObject &&!isRotating)
            {
                CurrentObject.useGravity = true;
                CurrentColider.excludeLayers = NothingLayer;
                CurrentObject = null;
                CurrentColider = null;
                ObjectTransform = null;

                objectPicked = false;
                return;
            }

            //checking if player is able to pick up object
            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit hitInfo, PickUpRange, PickUpMask))
            {
                //getting object variables
                CurrentObject = hitInfo.rigidbody;
                CurrentColider = hitInfo.collider;
                ObjectTransform = hitInfo.transform;

                //turning off gravity and turning off collision with player
                CurrentObject.useGravity = false;
                CurrentColider.excludeLayers = PlayerLayer;

                objectPicked = true;

                
            }
        }

        //checking if player is holding object
        if(objectPicked)
        {
            RotateObject();
        }
    }

    void FixedUpdate()
    {
        //checking if player is holding object
        if(CurrentObject)
        {
            //object is following players cursor
            Vector3 DirectionToPoint = PickUpTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 45f * DistanceToPoint;
        }
        
    }

    void RotateObject()
    {
        // if player holds key R, he can rotate the object with his mouse
        if(Input.GetKey(KeyCode.R))
        {
            isRotating = true;

            float XaxisRotation = Input.GetAxis("Mouse X") * mouseLook.sensitivity * Time.fixedDeltaTime;
            float YaxisRotation = Input.GetAxis("Mouse Y") * mouseLook.sensitivity * Time.fixedDeltaTime;

            ObjectTransform.Rotate(Vector3.down, XaxisRotation);
            if(!lockRotation)
            {
                ObjectTransform.Rotate(Vector3.right, YaxisRotation);
            }
        }
        else
        {
            //changing variable back to false, so player can rotate again with camera
            isRotating = false;
        }
    }

}
