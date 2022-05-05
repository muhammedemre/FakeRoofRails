using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITaskOfficer : MonoBehaviour
{
    public void LevelStartButton()
    {
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.LevelStart);
    }

    public void ReplayButton()
    {
        LevelManager.instance.levelLoadOfficer.CreateTheLevel();
    }
}
