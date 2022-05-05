using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActor : MonoBehaviour
{
    public CameraFollowAndCinematicOfficer cameraFollowAndCinematicOfficer;
    public Transform cameraAnchor, mainCamera;

    public void GameStartProcess()
    {
        cameraFollowAndCinematicOfficer.GameStartProcess();
    }
    
    public void LevelInstantiateProcess()
    {
        cameraFollowAndCinematicOfficer.LevelInstantiateProcess();
    }
    public  void LevelIsSuccessfullyCreatedProcess()
    {
        cameraFollowAndCinematicOfficer.LevelIsSuccessfullyCreatedProcess();
    }
    public  void LevelStartProcess()
    {
        cameraFollowAndCinematicOfficer.LevelStartProcess();
    }

    public void LevelFinishProcess()
    {
        cameraFollowAndCinematicOfficer.followON = false;
    }
}
