using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int numMechanism;
    [Space]
    public bool isOn;


    public List<ForcePlatform> mechanism;
    private float platformSize = 100f;
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
            nowSize = Mathf.MoveTowards(nowSize, platformSize, Time.deltaTime * 100);
        else
            nowSize = Mathf.MoveTowards(nowSize, 0, Time.deltaTime * 100);

        col.center = new Vector3(0, 0, 1.5f - nowSize / 66.66f);
        col.size = new Vector3(col.size.x, col.size.y, 3f - nowSize / 33.33f);
        mesh.SetBlendShapeWeight(0, nowSize);

    }

    public void AddMechanism(ForcePlatform pl)
    {
        if (!mechanism.Contains(pl))
            mechanism.Add(pl);
        Check();
    }

    public void DeleteMechanism(ForcePlatform pl)
    {
        if (mechanism.Contains(pl))
            mechanism.Remove(pl);
        Check();
    }

    private void Check()
    {
        if (mechanism.Count == numMechanism)
            isOn = true;
        else
            isOn = false;
    }
}
