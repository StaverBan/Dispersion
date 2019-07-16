using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{

    public Transform JumpTo;
    public float angle;
    public bool isDo;
    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player")&&!isDo)
        {
           
            player.GetComponent<Rigidbody>().AddForce(direction() * Speed(), ForceMode.VelocityChange);
            isDo = true;
        }
    }

    Vector3 direction()
    {
        if (angle == 90)
        {
            return Vector3.up;
        }
        if (angle == 60)
        {
            float y = Mathf.Sin(Mathf.PI / 3);
            float z = Mathf.Cos(Mathf.PI / 3);
            return new Vector3(0, y, z);
        }
        if (angle == 45)
        {
            float y = Mathf.Sin(Mathf.PI / 4);
            float z = Mathf.Cos(Mathf.PI / 4);
            return new Vector3(0, y, z);
        }
        if (angle == 30)
        {
            float y = Mathf.Sin(Mathf.PI / 6);
            float z = Mathf.Cos(Mathf.PI / 6);
            return new Vector3(0, y, z);
        }
        return Vector3.zero;

    }

   float Speed()
    {
        float distance = Vector3.Distance(transform.position, JumpTo.position);
        float sin = Mathf.Sin(angle * Mathf.PI / 180);
        float cos = Mathf.Cos(angle * Mathf.PI / 180);
        float speed = distance * 9.8f / (2*sin * cos);
        Debug.Log(Mathf.Sqrt(speed));
        return Mathf.Sqrt(speed);
    }
}
