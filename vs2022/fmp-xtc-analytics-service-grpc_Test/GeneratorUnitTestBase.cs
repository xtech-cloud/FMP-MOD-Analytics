
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.88.0.  DO NOT EDIT!
//*************************************************************************************

public abstract class GeneratorUnitTestBase : IClassFixture<TestFixture>
{
    /// <summary>
    /// 测试上下文
    /// </summary>
    protected TestFixture fixture_ { get; set; }

    public GeneratorUnitTestBase(TestFixture _testFixture)
    {
        fixture_ = _testFixture;
    }


    [Fact]
    public abstract Task RecordTest();

}
