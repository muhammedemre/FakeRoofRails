using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using DG.Tweening;

public class StickSizeOfficer : MonoBehaviour
{
    [SerializeField] private StickActor stickActor;
    [SerializeField] private Transform leftCylinder, rightCylinder;
    [SerializeField] private float scaleUPAmount, scaleUPDuration, allignDelay, allighDuration;

    private Transform previousObstacle = null;

    public void ResizeTheStick(Transform _obstacle)
    {
        if (previousObstacle != _obstacle)
        {
            Transform selectedCylinder = WhichCylinderShouldBeCut(_obstacle);
            SetTheSidesSticksSize(_obstacle, selectedCylinder);
        }
    }

    Transform WhichCylinderShouldBeCut(Transform _obstacle)
    {
        if ((_obstacle.position.x - stickActor.player.position.x) <= 0)
        {
            return leftCylinder;
        }
        else
        {
            return rightCylinder;
        }
    }

    void SetTheSidesSticksSize(Transform _obstacle, Transform _cylinder)
    {
        CylinderActor cylinderActor =  _cylinder.GetComponent<CylinderActor>();
        Transform counterCylinder = CreateTheCounterCylinder(cylinderActor);
        FindAndSetTheStickSize(_obstacle, _cylinder);
        FindAndSetTheStickSize(_obstacle, counterCylinder);
        counterCylinder.SetParent(LevelManager.instance.levelLoadOfficer.currentLevelActor.transform);
        counterCylinder.GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine(AllignTheStickToCenter());
    }

    Transform CreateTheCounterCylinder(CylinderActor _cylinderActor)
    {
        Transform tempCounterCylinder = Instantiate(_cylinderActor.counterCylinder, _cylinderActor.farEdge.position, _cylinderActor.counterCylinder.rotation, transform );
        return tempCounterCylinder;
    }

    void FindAndSetTheStickSize(Transform _obstacle, Transform _cylinder)
    {
        float distance = MeasureTheDifferenceBetweenObstacleAndCylinder(_obstacle, _cylinder);
        _cylinder.localScale = new Vector3((distance / 2), _cylinder.localScale.y, _cylinder.localScale.z);
    }

    float MeasureTheDifferenceBetweenObstacleAndCylinder(Transform _obstacle, Transform _cylinder)
    {
        float distance = 0;
        
        distance = _obstacle.position.x - _cylinder.position.x;
    
        return Mathf.Abs(distance);
    }
    
    public void ScaleUpTheStick()
    {
        ScalingTheStick(leftCylinder);
        ScalingTheStick(rightCylinder);
    }

    void ScalingTheStick(Transform _cylinder)
    {
        float newScaleX = _cylinder.localScale.x + scaleUPAmount;
        _cylinder.DOScaleX(newScaleX, scaleUPDuration);
    }

    IEnumerator AllignTheStickToCenter()
    {
        yield return new WaitForSeconds(allignDelay);
        Alligning();

    }

    void Alligning()
    {
        float totalLengthOfTheStick = rightCylinder.localScale.x + leftCylinder.localScale.x;
        rightCylinder.DOScaleX(totalLengthOfTheStick / 2, allighDuration);
        leftCylinder.DOScaleX(totalLengthOfTheStick / 2, allighDuration);
    }

    #region Button

    [Button("SizeTheStick", ButtonSizes.Large)]
    void ButtonStickSizer()
    {
        ScaleUpTheStick();
    }
    
    #endregion
}
