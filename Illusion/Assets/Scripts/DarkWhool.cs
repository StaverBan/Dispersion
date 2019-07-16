using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWhool : MonoBehaviour
{
    public Vector3 direction;
    public float size;
    public float speed;


    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, size))
        {
            if (hit.collider)
                direction = -direction;
        }
        transform.localScale = Vector3.one * size;
        transform.position+=direction * Time.deltaTime*speed/size;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction * speed);
    }
}
