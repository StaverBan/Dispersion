using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float platformSize;

    public bool isOn;

    private float nowSize = 0;
    private BoxCollider col;
    private SkinnedMeshRenderer mesh;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
        mesh = GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        if (isOn)
            nowSize = Mathf.MoveTowards(nowSize, platformSize, Time.deltaTime * 5);
        else
            nowSize = Mathf.MoveTowards(nowSize, 0, Time.deltaTime * 2);

        col.center = new Vector3(0, 0, nowSize / 4);
        col.size = new Vector3(col.size.x, col.size.y, nowSize / 2);
        mesh.SetBlendShapeWeight(0, nowSize);

    }

}
