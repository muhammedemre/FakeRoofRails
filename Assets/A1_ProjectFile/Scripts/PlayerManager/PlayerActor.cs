using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    public PlayerMoveOfficer playerMoveOfficer;
    public PlayerAnimationOfficer playerAnimationOfficer;
    public PlayerInteractionOfficer playerInteractionOfficer;
    public PlayerDeathOfficer playerDeathOfficer;
    public StickActor stickActor;

    public void LevelIsSuccessfullyCreatedProcess()
    {
        // playerAnimationOfficer.PlayIdle();
    }

    public void LevelStartProcess()
    {
        playerAnimationOfficer.PlayRun();
        playerMoveOfficer.canMove = true;
    }
    
    public void LevelFinishProcess()
    {
        playerMoveOfficer.canMove = false;
        playerAnimationOfficer.PlayIdle();
    }
}
