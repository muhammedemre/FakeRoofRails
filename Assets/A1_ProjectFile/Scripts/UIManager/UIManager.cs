using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    public static UIManager instance;
    public UIHandleOfficer uIHandleOfficer;
    public UITaskOfficer UITaskOfficer;

    private void Awake()
    {
        StaticCheck();
    }
    
    void StaticCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    
    
    public override void LevelInstantiateProcess()
    {
        uIHandleOfficer.LevelInstantiateProcess();
    }

    public override void LevelStartProcess()
    {
        uIHandleOfficer.LevelStartProcess();
    }

    public override void LevelFinishProcess()
    {
        uIHandleOfficer.LevelFinishProcess();
    }
}
