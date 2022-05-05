using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Manager : SerializedMonoBehaviour,IObserver
{
    public ObserverOfficer observerOfficer;
    [SerializeField] private List<ObserverSubjects> subscribeList = new List<ObserverSubjects>();
    
    private void Start()
    {
        observerOfficer.Subscriber(this, subscribeList);
        AssignEvents(observerOfficer);
    }
    public void GetUpdated(ISubject subject)
    {
        if (subject is ObserverSubject observerSubject)
        {
            observerOfficer.subjectEvents[observerSubject.subjectType].Invoke();
        }
    }
    public void AssignEvents(ObserverOfficer observerOfficer)
    {
        observerOfficer.subjectEvents[ObserverSubjects.GameStart] += GameStartProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelInstantiate] += LevelInstantiateProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelisSuccessfullyCreated] += LevelIsSuccessfullyCreatedProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelStart] += LevelStartProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelFinish] += LevelFinishProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelEnd] += LevelEndProcess;
        
    }

    public virtual void GameStartProcess()
    {
        print(gameObject.name+"Manager START PROCESS");
    }
    
    public virtual void LevelInstantiateProcess()
    {
        print(gameObject.name+"  LevelInstantiateProcess");
    }
    public virtual void LevelIsSuccessfullyCreatedProcess()
    {
        print(gameObject.name+"  LevelIsSuccessfullyCreated");
    }
    
    public virtual void LevelStartProcess()
    {
        print(gameObject.name+"  LevelStartProcess");
    }
    public virtual void LevelFinishProcess()
    {
        print(gameObject.name+"  LevelFinishProcess");
    }
    public virtual void LevelEndProcess()
    {
        print(gameObject.name+"  LevelEndProcess");
    }

    
}
