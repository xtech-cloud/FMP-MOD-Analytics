
using XTC.FMP.MOD.Analytics.LIB.Proto;

public class TrackerTest : TrackerUnitTestBase
{
    public TrackerTest(TestFixture _testFixture)
        : base(_testFixture)
    {
    }


    public override async Task RecordTest()
    {
        var request = new TrackerRecordRequest();
        request.AppID = "test";
        request.SerialNumber = "00000000000000000";
        request.UserID = "";
        request.EventID = "RecordTest";
        request.EventParameter = "1";
        var response = await fixture_.getServiceTracker().Record(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

}
