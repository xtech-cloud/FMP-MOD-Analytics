
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.80.1.  DO NOT EDIT!
//*************************************************************************************

using XTC.FMP.MOD.Analytics.App.Service;

public abstract class TestFixtureBase : IDisposable
{
    public TestServerCallContext context { get; set; }

    public TestFixtureBase()
    {
        context = TestServerCallContext.Create();
    }

    public virtual void Dispose()
    {

        var options = new DatabaseOptions();
        var mongoClient = new MongoDB.Driver.MongoClient(options.Value.ConnectionString);
        mongoClient.DropDatabase(options.Value.DatabaseName);

    }


    protected GeneratorService? serviceGenerator_ { get; set; }

    public GeneratorService getServiceGenerator()
    {
        if(null == serviceGenerator_)
        {
            newGeneratorService();
        }
        return serviceGenerator_!;
    }

    /// <summary>
    /// 实例化服务
    /// </summary>
    /// <example>
    /// serviceGenerator_ = new GeneratorService(new GeneratorDAO(new DatabaseOptions()));
    /// </example>
    protected abstract void newGeneratorService();

    protected HealthyService? serviceHealthy_ { get; set; }

    public HealthyService getServiceHealthy()
    {
        if(null == serviceHealthy_)
        {
            newHealthyService();
        }
        return serviceHealthy_!;
    }

    /// <summary>
    /// 实例化服务
    /// </summary>
    /// <example>
    /// serviceHealthy_ = new HealthyService(new HealthyDAO(new DatabaseOptions()));
    /// </example>
    protected abstract void newHealthyService();

    protected TrackerService? serviceTracker_ { get; set; }

    public TrackerService getServiceTracker()
    {
        if(null == serviceTracker_)
        {
            newTrackerService();
        }
        return serviceTracker_!;
    }

    /// <summary>
    /// 实例化服务
    /// </summary>
    /// <example>
    /// serviceTracker_ = new TrackerService(new TrackerDAO(new DatabaseOptions()));
    /// </example>
    protected abstract void newTrackerService();

}
