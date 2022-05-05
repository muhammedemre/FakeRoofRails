using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandleOfficer : MonoBehaviour
{
    [SerializeField] private Transform menuScreen, inGameScreen, successScreen, failScreen;
    [SerializeField]private List<Transform> screenList = new List<Transform>();
    
    public void LevelInstantiateProcess()
    {
        CloseAllScreens();
        menuScreen.gameObject.SetActive(true);
    }

    public void LevelStartProcess()
    {
        CloseAllScreens();
        inGameScreen.gameObject.SetActive(true);
    }
    
    public void LevelFinishProcess()
    {
        StartCoroutine(LevelRestart());
    }

    IEnumerator LevelRestart()
    {
        yield return new WaitForSeconds(2f);
        LevelManager.instance.levelLoadOfficer.CreateTheLevel();
    }

    void CloseAllScreens()
    {
        foreach (Transform screen in screenList)
        {
            screen.gameObject.SetActive(false);
        }
    }
}
