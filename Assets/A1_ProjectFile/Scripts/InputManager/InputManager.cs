using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Manager
{
    public static InputManager instance;

    public GetInputOfficer getInputOfficer;
    public InputDragOfficer inputDragOfficer;
    public InputHoldOfficer inputHoldOfficer;
    public InputSlideOfficer inputSlideOfficer;
    public InputSwipeOfficer inputSwipeOfficer;
    public InputTouchOfficer inputTouchOfficer;

    private void Awake()
    {
        SingletonCheck();
    }
    
    void SingletonCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public override void LevelStartProcess()
    {
        getInputOfficer.touchable = true;
    }

    public override void LevelFinishProcess()
    {
        getInputOfficer.touchable = false;
    }
}
