using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public enum TypeOfMechanism
    {
        ForcePlatform,
        ForceButton
    }
    public TypeOfMechanism setMechanism;

    public LineChangeColor[] lines;

    public mechanism[] mech;

    public bool isActivate;




    public void Activate()
    {
        isActivate = true;
        for (int ab = 0; ab < lines.Length; ab++)
            lines[ab].ChangeColor(isActivate);
        for (int a = 0; a < mech.Length; a++) 
            mech[a].AddAction(this);
    }
    public void DisActivate ()
    {
        isActivate = false;
        for (int ab = 0; ab < lines.Length; ab++)
            lines[ab].ChangeColor(isActivate);
        for (int a = 0; a < mech.Length; a++)
            mech[a].DeleteAction(this);
    }

    public void ButtonOn()
    {
        if (isActivate)
            DisActivate();
        else
            Activate();
    }
}
