using Sirenix.OdinInspector;
using UnityEngine;

public class SlideBarActor : MonoBehaviour
{
    [SerializeField] private Transform leftBar, rightBar;

    void RepositionTheBars(float distance)
    {
        Vector3 newPosLB = new Vector3(-distance, leftBar.position.y, leftBar.position.z);
        leftBar.position = newPosLB;
        Vector3 newPosRB = new Vector3(distance, rightBar.position.y, rightBar.position.z);
        rightBar.position = newPosRB;
    }

    #region Button
    [Button("RePositionTheBars", ButtonSizes.Large)]
    void ButtonRePositionTheBars(float distance)
    {
        RepositionTheBars(distance);
    }
    #endregion
    
}
