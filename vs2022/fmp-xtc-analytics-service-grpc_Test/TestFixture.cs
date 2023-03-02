
using XTC.FMP.MOD.Analytics.App.Service;

/// <summary>
/// 测试上下文，用于共享测试资源
/// </summary>
public class TestFixture : TestFixtureBase
{
    private SingletonServices singletonServices_;

    public TestFixture()
        : base()
    {
        singletonServices_ = new SingletonServices(new DatabaseOptions());
    }

    public override void Dispose()
    {
        base.Dispose();
    }


    protected override void newGeneratorService()
    {
        serviceGenerator_ = new GeneratorService(singletonServices_);
    }

    protected override void newHealthyService()
    {
        throw new NotImplementedException();
        //serviceHealthy_ = new HealthyService(singletonServices_);
    }

    protected override void newTrackerService()
    {
        serviceTracker_ = new TrackerService(singletonServices_);
    }

}
