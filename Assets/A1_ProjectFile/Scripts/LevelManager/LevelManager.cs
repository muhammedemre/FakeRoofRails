using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager
{
    public static LevelManager instance;
    public LevelLoadOfficer levelLoadOfficer;

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
    
    public override void GameStartProcess()
    {
        levelLoadOfficer.CreateTheLevel();
    }

    public override void LevelInstantiateProcess()
    {
        levelLoadOfficer.currentLevelActor.LevelInstantiate();
    }

    public override void LevelEndProcess()
    {
        
    }
}
