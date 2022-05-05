using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CameraManager : Manager
{
    public static CameraManager instance;
    
    [Serializable]
    public class CameraPositionEnumVector3Dict : SerializableDictionary<CameraPositionsEnum, Vector3> { }
    public CameraPositionEnumVector3Dict mainCameraPositions = new CameraPositionEnumVector3Dict();
    public CameraPositionEnumVector3Dict mainCameraRotations = new CameraPositionEnumVector3Dict();
    public CameraPositionEnumVector3Dict cameraAnchorCameraRotations = new CameraPositionEnumVector3Dict();
    
    public CameraActor cameraActor;

    [SerializeField] private CameraDataContainer cameraDataContainer;

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
    
    
    public override void GameStartProcess()
    {
        LoadCameraData();
        cameraActor.GameStartProcess();
    }

    public override void LevelInstantiateProcess()
    {
        cameraActor.LevelInstantiateProcess();
    }

    public override void LevelIsSuccessfullyCreatedProcess()
    {
        cameraActor.LevelIsSuccessfullyCreatedProcess();
    }

    public override void LevelStartProcess()
    {
        cameraActor.LevelStartProcess();
    }

    public override void LevelFinishProcess()
    {
        cameraActor.LevelFinishProcess();
    }


    void SaveMainCamSpecs(CameraPositionsEnum camState) 
    {
        print("SaveMainCamSpecs");
        DictContainCheck(mainCameraPositions, camState);
        DictContainCheck(mainCameraRotations, camState);
        mainCameraPositions[camState] = cameraActor.mainCamera.localPosition;
        mainCameraRotations[camState] = cameraActor.mainCamera.localEulerAngles;
    }
    void SaveCameraAnchorSpecs(CameraPositionsEnum camState) 
    {
        DictContainCheck(cameraAnchorCameraRotations, camState);
        cameraAnchorCameraRotations[camState] = cameraActor.cameraAnchor.eulerAngles;
    }

    void DictContainCheck(CameraPositionEnumVector3Dict dict, CameraPositionsEnum camState) 
    {
        if (!dict.ContainsKey(camState))
        {
            dict.Add(camState, new Vector3());
        }
    }

    void SaveCameraData() 
    {
        cameraDataContainer.mainCameraPoses = mainCameraPositions;
        cameraDataContainer.mainCameraRots = mainCameraRotations;
        cameraDataContainer.cameraAnchorCameraRots = cameraAnchorCameraRotations;
    }

    void LoadCameraData() 
    {
        mainCameraPositions = cameraDataContainer.mainCameraPoses;
        mainCameraRotations = cameraDataContainer.mainCameraRots;
        cameraAnchorCameraRotations = cameraDataContainer.cameraAnchorCameraRots;
    }
    
    
    #region Button
    
    [Title("Select the cam state then Invoke")]
    [Button("Save Cam Pos", ButtonSizes.Large)]
    void ButtonCameraPositioner(CameraPositionsEnum camState)
    {
        print("ButtonCameraPositioner");
        SaveMainCamSpecs(camState);
        SaveCameraAnchorSpecs(camState);
        SaveCameraData();
    }
    #endregion
}
