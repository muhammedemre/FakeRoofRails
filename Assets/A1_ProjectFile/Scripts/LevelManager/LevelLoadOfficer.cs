using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LevelLoadOfficer : MonoBehaviour
{
    [SerializeField] private List<Transform> levelList = new List<Transform>();
    public LevelActor currentLevelActor;
    

    public void CreateTheLevel()
    {
        ClearPreviousLevel();
        Transform tempLevel = Instantiate(levelList[0]);
        currentLevelActor = tempLevel.GetComponent<LevelActor>();
        
        
    }

    void ClearPreviousLevel()
    {
        if (currentLevelActor != null)
        {
            Destroy(currentLevelActor.gameObject);
        }
        
    }
}
