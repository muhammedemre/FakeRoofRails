using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActor : MonoBehaviour
{
    [SerializeField] private PlayerActor playerActor;
    public Transform platformBorderRight, platformBorderLeft;

    private void Start()
    {
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.LevelInstantiate);
    }

    public void LevelInstantiate()
    {
        AssignThePlayerRelateds();
        
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.LevelisSuccessfullyCreated);
    }

    void AssignThePlayerRelateds()
    {
        PlayerManager.instance.playerActor = playerActor;
        playerActor.playerMoveOfficer.AssignPlatformBorders(platformBorderRight, platformBorderLeft);
    }
}
