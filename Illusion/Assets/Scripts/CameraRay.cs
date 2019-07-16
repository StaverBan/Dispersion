using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public UnityEngine.UI.Image cursor;

    public Vector3 positionInHand;

    public Transform objectInHand;


    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.distance < 2)
            {
                if (hit.transform.CompareTag("CanTake"))
                {
                    if (Input.GetKeyDown(KeyCode.E) && !objectInHand)
                    { 
                        objectInHand = hit.transform;
                        objectInHand.GetComponent<Rigidbody>().useGravity = false;
                    }
                    cursor.color = Color.red;
                }
                if (hit.transform.CompareTag("Button")){ 
                  
                    if (Input.GetKeyDown(KeyCode.E))
                        hit.transform.GetComponent<Actions>().ButtonOn();
                    cursor.color = Color.red;
                }
                
            }
            else
            {
                cursor.color = Color.white;
            }
        }

        
    }

    private void FixedUpdate()
    {
        if (objectInHand)
        {
           
            objectInHand.transform.position = Vector3.Lerp(objectInHand.transform.position, transform.TransformPoint(positionInHand), Time.deltaTime * 5);
            if (Input.GetKeyUp(KeyCode.F))
            {
                objectInHand.GetComponent<Rigidbody>().useGravity = true;
                objectInHand = null;
            }

        }
    }
}
