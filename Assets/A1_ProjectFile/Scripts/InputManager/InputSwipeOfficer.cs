using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSwipeOfficer : InputAbstractOfficer
{
    public delegate void SwipeLevelTask(Vector2 touchPos);
    
    public SwipeLevelTask swipeLevelTaskTouchStart;
    public SwipeLevelTask swipeLevelTaskTouchMove;
    public SwipeLevelTask swipeLevelTaskTouchEnded;
    private void Start()
    {
        getInputOfficer.InputSwipe += InputSwipeProcess;
    }

    void InputSwipeProcess(bool touchStart, bool touchMoved, bool touchEnded, Vector2 touchPos)
    {
        if (touchStart)
        {
            swipeLevelTaskTouchStart(touchPos);
        }
        else if (touchMoved)
        {
            swipeLevelTaskTouchMove(touchPos);
        }
        else if (touchEnded)
        {
            swipeLevelTaskTouchEnded(touchPos);
        }
    }
}
