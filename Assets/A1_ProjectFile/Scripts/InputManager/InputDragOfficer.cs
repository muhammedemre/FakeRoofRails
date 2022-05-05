using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InputDragOfficer : InputAbstractOfficer
{
    public delegate void DragLevelTask(Vector2 touchPos);

    public DragLevelTask dragLevelTaskTouchStart;
    public DragLevelTask dragLevelTaskTouchMove;
    public DragLevelTask dragLevelTaskTouchEnded;

    private void Start()
    {
        getInputOfficer.InputDrag += InputDragProcess;
    }

    void InputDragProcess(bool touchStart, bool touchMoved, bool touchEnded, Vector2 touchPos)
    {
        if (touchStart)
        {
            dragLevelTaskTouchStart(touchPos);
        }
        else if (touchMoved)
        {
            dragLevelTaskTouchMove(touchPos);
        }
        else if (touchEnded)
        {
            dragLevelTaskTouchEnded(touchPos);
        }
    }
}
