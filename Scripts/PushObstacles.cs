using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObstacles : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] LayerMask objects;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //getting rigidbody of collided object
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        RaycastHit raycastHit;
        //checking if player is standing on object
        if(Physics.Raycast(transform.position, -transform.up, out raycastHit, 3f, objects))
        {
            Rigidbody rayRigid = raycastHit.collider.attachedRigidbody;


            //if player is not stanging on object, it can be pushed
            if(rigidbody != null && rigidbody != rayRigid)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y=0;
                forceDirection.Normalize();
                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }
        else
        {
            if(rigidbody != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y=0;
                forceDirection.Normalize();
                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }

        
    }


}
