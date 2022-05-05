public class PlayerManager : Manager
{
    public static PlayerManager instance;
    public PlayerActor playerActor;

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
    
    
    public override void LevelIsSuccessfullyCreatedProcess()
    {
        playerActor.LevelIsSuccessfullyCreatedProcess();
    }

    public override void LevelStartProcess()
    {
        playerActor.LevelStartProcess();
    }
    
    public override void LevelFinishProcess()
    {
        playerActor.LevelFinishProcess();
    }
}
