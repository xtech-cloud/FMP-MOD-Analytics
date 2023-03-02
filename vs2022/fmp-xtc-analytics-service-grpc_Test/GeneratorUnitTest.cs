
using Newtonsoft.Json;
using System.Text;
using XTC.FMP.MOD.Analytics.LIB.Proto;

public class GeneratorTest : GeneratorUnitTestBase
{
    public GeneratorTest(TestFixture _testFixture)
        : base(_testFixture)
    {
    }


    public override async Task RecordTest()
    {

        {
            var request = new TrackerRecordRequest();
            for (int i = 0; i < 10; i++)
            {
                request.AppID = "Generator";
                request.SerialNumber = i.ToString();
                request.UserID = "";
                request.EventID = "Generator.Record." + (i / 5).ToString();
                request.EventParameter = "2222";
                var response = await fixture_.getServiceTracker().Record(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }

        {
            string content = "";
            List<XTC.FMP.MOD.Analytics.App.Service.RecordEntity>? entityS;

            // 记录生成前100秒
            long startTime = (DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks) / 10000 - 100 * 1000;
            // 记录生成后100秒
            long endTime = (DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks) / 10000 + 100 * 1000;
            // AppID字段
            var request = new GeneratorRecordRequest();
            request.StartTime = startTime;
            request.EndTime = endTime;
            request.AppID = "Generator";
            var response = await fixture_.getServiceGenerator().Record(request, fixture_.context);
            Assert.Equal(0, response.Status.Code);
            content = Encoding.UTF8.GetString(Convert.FromBase64String(response.Content));
            entityS = System.Text.Json.JsonSerializer.Deserialize<List<XTC.FMP.MOD.Analytics.App.Service.RecordEntity>>(content);
            Assert.Equal(10, entityS.Count);

            // AppID + Event + 字段
            request.EventID = "Generator.Record.0";
            response = await fixture_.getServiceGenerator().Record(request, fixture_.context);
            Assert.Equal(0, response.Status.Code);
            content = Encoding.UTF8.GetString(Convert.FromBase64String(response.Content));
            entityS = System.Text.Json.JsonSerializer.Deserialize<List<XTC.FMP.MOD.Analytics.App.Service.RecordEntity>>(content);
            Assert.Equal(5, entityS.Count);

            // AppID + EventID + SerialNumber字段
            request.SerialNumber = "3";
            response = await fixture_.getServiceGenerator().Record(request, fixture_.context);
            Assert.Equal(0, response.Status.Code);
            content = Encoding.UTF8.GetString(Convert.FromBase64String(response.Content));
            entityS = System.Text.Json.JsonSerializer.Deserialize<List<XTC.FMP.MOD.Analytics.App.Service.RecordEntity>>(content);
            Assert.Equal(1, entityS.Count);
        }
    }

}
