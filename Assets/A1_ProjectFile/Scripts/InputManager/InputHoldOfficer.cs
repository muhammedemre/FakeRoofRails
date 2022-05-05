using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHoldOfficer : InputAbstractOfficer
{
    public delegate void HoldLevelTask(Vector2 touchPos);

    public HoldLevelTask holdLevelTask;
    private void Start()
    {
        getInputOfficer.InputHold += InputHoldProcess;
    }

    void InputHoldProcess(bool touchStart, bool touchMoved, bool touchEnded, Vector2 touchPos)
    {
        holdLevelTask(touchPos);
    }
}
