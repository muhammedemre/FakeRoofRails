using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : SerializedMonoBehaviour
{
    public static GameManager instance;
    public GameManagerObserverOfficer gameManagerObserverOfficer;

    private void Awake()
    {
        StaticCheck();
        
        gameManagerObserverOfficer.CreateSubjects();
    }

    private void Start()
    {
        gameManagerObserverOfficer.Publish(ObserverSubjects.GameStart);
    }

    void StaticCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }
    
}
