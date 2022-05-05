using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchOfficer : InputAbstractOfficer
{

    public delegate void TouchLevelTask(bool touchStart, bool touchMoved, bool touchEnded, Vector2 touchPos);

    public TouchLevelTask touchLevelTask;
    
    private void Start()
    {
        getInputOfficer.InputTouch += InputTouchProcess;
    }

    void InputTouchProcess(bool touchStart, bool touchMoved, bool touchEnded, Vector2 touchPos)
    {
        touchLevelTask(touchStart, touchMoved, touchEnded, touchPos);
    }
}
