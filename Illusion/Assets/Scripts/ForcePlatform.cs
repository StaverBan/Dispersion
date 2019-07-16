using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{

    public Actions forcePlatform;

    private void OnTriggerExit(Collider other)
    {
        forcePlatform.DisActivate();
    }
    private void OnTriggerEnter(Collider other)
    {

        forcePlatform.Activate();
    }
    private void OnTriggerStay(Collider other)
    {
        forcePlatform.Activate();


    }


}

