using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverOfficer: MonoBehaviour
{
    public Dictionary<ObserverSubjects, SubjectEventHandler> subjectEvents =
        new Dictionary<ObserverSubjects, SubjectEventHandler>();
    
    public delegate void SubjectEventHandler();
    event SubjectEventHandler GameStarted;
    event SubjectEventHandler LevelInstantiate;
    event SubjectEventHandler LevelisSuccessfullyCreated;
    event SubjectEventHandler LevelStart;
    event SubjectEventHandler LevelFinish;
    event SubjectEventHandler LevelEnd;
    
    
    public void Subscriber(IObserver observer, List<ObserverSubjects> _subjectTypeList)
    {
        GameManagerObserverOfficer gameManagerObserverOfficer = GameManager.instance.gameManagerObserverOfficer;

        foreach (ObserverSubjects subjectType in _subjectTypeList)
        {
            gameManagerObserverOfficer.observerSubjectDict[subjectType].Subscribe(observer);
        }
        
        AddEvents();
    }

    void AddEvents()
    {
        subjectEvents.Add(ObserverSubjects.GameStart, GameStarted);
        subjectEvents.Add(ObserverSubjects.LevelInstantiate, LevelInstantiate);
        subjectEvents.Add(ObserverSubjects.LevelisSuccessfullyCreated, LevelisSuccessfullyCreated);
        subjectEvents.Add(ObserverSubjects.LevelStart, LevelStart);
        subjectEvents.Add(ObserverSubjects.LevelFinish, LevelFinish);
        subjectEvents.Add(ObserverSubjects.LevelEnd, LevelEnd);
    }
}
