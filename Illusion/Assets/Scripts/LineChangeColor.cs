using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChangeColor : MonoBehaviour
{
    public float stage;

    private bool isChanges;
    private float nowTime;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public void Update()
    {
        if (nowTime > 0)
            nowTime -= Time.deltaTime;
        else
        {
            if(isChanges)
                mat.color = Color.Lerp(mat.color, Color.red, Time.deltaTime * 5);
            else
                mat.color = Color.Lerp(mat.color, Color.white, Time.deltaTime * 5);

        }
      
    }

    public void ChangeColor(bool isChange)
    {

        if (isChanges != isChange)
        {
            nowTime = stage * 0.05f;
            isChanges = isChange;
        }
    }
}
