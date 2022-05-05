using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathOfficer : MonoBehaviour
{
    public void DeathProcess()
    {
        PlayerManager.instance.playerActor.playerMoveOfficer.canMove = false;
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.LevelFinish);
    }
}
