using UnityEngine;
using DG.Tweening;

public class CameraFollowAndCinematicOfficer : MonoBehaviour
{
    public bool followON = false;
    public Transform target;
    [SerializeField] private float levelStartMoveDuration, moveSpeedSmoothTimeHorizontal, moveSpeedSmoothTime;
    
    Vector3 smoothDampRefVector = Vector3.zero;
    Vector3 smoothDampRefHorizontalVector = Vector3.zero;
    public void GameStartProcess()
    {
        MoveGameStart();
    }
    public void LevelInstantiateProcess()
    {
        print("LevelInstantiateProcess + camFollow");
        MoveGameStart();
    }
    public void LevelIsSuccessfullyCreatedProcess()
    {
        target = PlayerManager.instance.playerActor.transform;
    }

    public  void LevelStartProcess()
    {
        MoveLevelStart();
        followON = true;
    }

    private void Update()
    {
        if (followON)
        {
            Follow();
        }
    }

    public void Follow()
    {
        if (followON) 
        {
            FollowHorizontal(); 
            FollowZAndY();
        }
    }
    
    void FollowHorizontal() 
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothDampRefHorizontalVector, moveSpeedSmoothTimeHorizontal);
    }
    public void FollowZAndY()
    {
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y, target.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothDampRefVector, moveSpeedSmoothTime);
    }
    
    void MoveGameStart()
    {
        CameraManager.instance.cameraActor.cameraAnchor.DOMove(Vector3.zero, 0f);
        transform.GetChild(0).DOLocalMove(CameraManager.instance.mainCameraPositions[CameraPositionsEnum.GameStart], 0f);
        transform.GetChild(0).DOLocalRotate(CameraManager.instance.mainCameraRotations[CameraPositionsEnum.GameStart], 0f);
        transform.DOLocalRotate(CameraManager.instance.cameraAnchorCameraRotations[CameraPositionsEnum.GameStart], 0f);
    }

    void MoveLevelStart()
    {
        transform.GetChild(0).DOLocalMove(CameraManager.instance.mainCameraPositions[CameraPositionsEnum.LevelStart], levelStartMoveDuration);
        transform.GetChild(0).DOLocalRotate(CameraManager.instance.mainCameraRotations[CameraPositionsEnum.LevelStart], levelStartMoveDuration);
        transform.DOLocalRotate(CameraManager.instance.cameraAnchorCameraRotations[CameraPositionsEnum.LevelStart], levelStartMoveDuration);
    }


}
