using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class FinishAreaActor : MonoBehaviour
{
    [SerializeField] private int levelAmount;
    [SerializeField] private List<Color> levelColorList = new List<Color>();
    [SerializeField] private Transform levelBoxPrefab, levelBoxPool;


    private void Start()
    {
        PlaceLevelBoxes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.LevelFinish);
        }
    }


    void PlaceLevelBoxes()
    {
        CleanThePool();
        int counter = 1;
        for (int i = 0; i < levelAmount; i++)
        {
            Vector3 placePos = new Vector3(transform.position.x, transform.position.y, (transform.position.z + (i*(levelBoxPrefab.localScale.z ))));
            Transform tempLevelBox = Instantiate(levelBoxPrefab, placePos, Quaternion.identity, levelBoxPool);
            tempLevelBox.name = counter.ToString();
            int colorIndex = i % levelColorList.Count;
            // print("COLOR INDEX : "+ colorIndex);
            tempLevelBox.GetComponent<MeshRenderer>().material.color = levelColorList[colorIndex];
        }
    }

    void CleanThePool()
    {
        int poolCount = levelBoxPool.childCount;
        for (int i = 0; i < poolCount; i++)
        {
            DestroyImmediate(levelBoxPool.GetChild(0).gameObject);
        }
        
    }

    #region Button

    [Button("FinishAreaLevelPlacer", ButtonSizes.Large)]
    void ButtonFinishAreaLevelPlacer()
    {
        PlaceLevelBoxes();
    }
    #endregion
}
