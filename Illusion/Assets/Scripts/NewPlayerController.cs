using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NewPlayerController : MonoBehaviour
{
    public float speed;

    public Transform head;

    public float sensetivity = 5f;
    public float headMinY = -44f;
    public float headMaxY = 44f;

    public float jumpForce = 10f;
    public float jumpDistance = 1.2f;

    public UnityEngine.UI.Image background;

    private Vector3 direction;
    private float h, v;
    private int layerMask;
    private Rigidbody body;
    private float rotationY;
    private bool isDead;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        body = GetComponent<Rigidbody>();
        Debug.Log(Mathf.Sign(2.6f));
    }

    private void FixedUpdate()
    {
        float nowSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            nowSpeed = speed * 1.5f;
        else
            nowSpeed = speed;
        if (GetJump())
        {
            body.AddForce(direction * nowSpeed, ForceMode.VelocityChange);
            if (Mathf.Abs(body.velocity.x) > nowSpeed * direction.x)
                body.velocity = new Vector3(nowSpeed * direction.x, body.velocity.y, body.velocity.z);
            if (Mathf.Abs(body.velocity.z) > nowSpeed * direction.z)
                body.velocity = new Vector3(body.velocity.x, body.velocity.y, nowSpeed * direction.z);
        }
        else
        {
            body.AddForce(direction * nowSpeed*Time.deltaTime/5, ForceMode.VelocityChange);
        }
        /*
                if (GetJump())
                    body.velocity = new Vector3(direction.x * nowSpeed, body.velocity.y, direction.z * nowSpeed);
                else
                    body.velocity += direction * nowSpeed * Time.deltaTime / 5 ;

            */
    }

    bool GetJump()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, jumpDistance))
            return true;
        else
            return false;
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        float RotationX = transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensetivity;
        rotationY += Input.GetAxis("Mouse Y") * sensetivity;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        head.localEulerAngles = new Vector3(-rotationY, 0, 0);
        transform.eulerAngles = new Vector3(0, RotationX, 0);

        direction = new Vector3(h, 0, v);
        direction = transform.TransformDirection(direction);

        

        if (Input.GetKeyDown(KeyCode.Space) && GetJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * jumpForce);
    }

    public void FallToDeadZone(Transform newPosition, float rotationCamera)
    {
        if (!isDead)
        {
            isDead = true;
            StartCoroutine(die(newPosition,rotationCamera));
        }
    }

    IEnumerator die(Transform newPos,float rotCamera)
    {
        while (background.color != Color.black)
        {
            background.color = Color.Lerp(background.color, Color.black, Time.deltaTime * 5);
            yield return null;
        }
        
        transform.position = newPos.position;
        rotationY = 0;
        transform.eulerAngles = new Vector3(0, rotCamera, 0);
        while (background.color != Color.clear)
        {
            background.color = Color.Lerp(background.color, Color.clear, Time.deltaTime * 5);
            yield return null;
        }
        isDead = false;

    }
}
