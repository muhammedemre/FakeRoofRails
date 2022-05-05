public class DataManager : Manager
{
    public static DataManager instance;

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
    
    
    public override void GameStartProcess()
    {
        // base.StartProcess();
        print("OVERRIDED START PROCESS");
    }
}
