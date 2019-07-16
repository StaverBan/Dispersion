using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechanism : MonoBehaviour
{
    public enum TypeOfMechanism {
        Door,
        Platform
    }

    public TypeOfMechanism setMechanism;

    private bool isOn;
    public int numOfAction;
    public float _offset;
    public float timerToActivate;
    private float nowSize = 0;
    public List<Actions> actionToOn;

    private bool changeTo,lastChange;

    private BoxCollider col;
    private SkinnedMeshRenderer mesh;

    private void Start()
    {
            col = GetComponent<BoxCollider>();
            mesh = GetComponent<SkinnedMeshRenderer>();
    }

    private void FixedUpdate()
    {

        if (setMechanism == TypeOfMechanism.Door)
        {
            if (isOn)
                nowSize = Mathf.MoveTowards(nowSize, 100, Time.deltaTime * 100);
            else
                nowSize = Mathf.MoveTowards(nowSize, 0, Time.deltaTime * 100);

            col.center = new Vector3(0, 0, 1.5f - nowSize / 66.66f);
            col.size = new Vector3(col.size.x, col.size.y, 3f - nowSize / 33.33f);
            mesh.SetBlendShapeWeight(0, nowSize);
        }
        if (setMechanism == TypeOfMechanism.Platform)
        {
            if (isOn)
                nowSize = Mathf.MoveTowards(nowSize, _offset, Time.deltaTime * 10);
            else
                nowSize = Mathf.MoveTowards(nowSize, 0, Time.deltaTime * 10);

            col.center = new Vector3(0, 0, nowSize / 4);
            col.size = new Vector3(col.size.x, col.size.y, nowSize / 2);
            mesh.SetBlendShapeWeight(0, nowSize);
        }
    }

    public void AddAction(Actions pl)
    {
        if (!actionToOn.Contains(pl))
            actionToOn.Add(pl);
       Check();
    }
    public void DeleteAction(Actions pl)
    {
        if (actionToOn.Contains(pl))
            actionToOn.Remove(pl);
       Check();
    }
    private void Check()
    {

        if (actionToOn.Count == numOfAction)
        {
            changeTo = true;
            if(lastChange==changeTo)
            StartCoroutine(WaitToAction(true));
            else
            {
                lastChange = changeTo;
                StopAllCoroutines();
                StartCoroutine(WaitToAction(true));
            }
        }
        else
        {
            changeTo = false;
            if (lastChange == changeTo)
                StartCoroutine(WaitToAction(false));
            else
            {
                lastChange = changeTo;
                StopAllCoroutines();
                StartCoroutine(WaitToAction(false));
            }
        }

    }

    public IEnumerator WaitToAction(bool state)
    {
        Debug.Log("Do");
        yield return new WaitForSeconds(timerToActivate);
        isOn = state;
    }
}
