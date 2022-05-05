using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManagerObserverOfficer : SerializedMonoBehaviour
{
    // public enum ObserverSubjects
    // {
    //     GameStart, MenuMap, LevelInstantiate, LevelEnd, GameQuit
    // }

    public Dictionary<ObserverSubjects, ObserverSubject> observerSubjectDict =
        new Dictionary<ObserverSubjects, ObserverSubject>();

    public void CreateSubjects()
    {
        foreach (ObserverSubjects subject in Enum.GetValues(typeof(ObserverSubjects)))
        {
            observerSubjectDict.Add(subject, new ObserverSubject(subject));
        }
    }

    public void Publish(ObserverSubjects notificationType)
    {
        observerSubjectDict[notificationType].NotifyObservers();
    }

    #region Button

    // [Title("Select the cam state then Invoke")]
    [Button("Notify Observers", ButtonSizes.Large)]
    void ButtonSendNotification(ObserverSubjects notificationType)
    {
        observerSubjectDict[notificationType].NotifyObservers();
    }
    #endregion
}
